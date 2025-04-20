using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ShowWithPositionAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float duration1;
        [SerializeField] private float duration2;

        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 maxPos;
        [SerializeField] private Vector3 endPos;


        [SerializeField] private bool needReturn;
        [SerializeField] private float delayBeforeReturn;

        protected override Sequence GetSequence()
        {
            root.localPosition = startPos;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOLocalMove(maxPos, duration1))
                .Append(root.DOLocalMove(endPos, duration2));

            if (needReturn)
            {
                seq
                    .AppendInterval(delayBeforeReturn)
                    .Append(root.DOLocalMove(maxPos, duration2))
                    .Append(root.DOLocalMove(startPos, duration1));
            }

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localPosition = startPos;
        }
    }
}
