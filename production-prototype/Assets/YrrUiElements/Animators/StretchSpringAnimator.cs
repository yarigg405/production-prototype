using DG.Tweening;
using UnityEngine;



namespace Yrr.UI.Animators
{
    internal sealed class StretchSpringAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 maxPos;
        [SerializeField] private Vector3 endPos;

        [SerializeField] private Vector3 startScale;
        [SerializeField] private Vector3 maxScale;
        [SerializeField] private Vector3 endScale;

        [SerializeField] private float duration1;
        [SerializeField] private float duration2;

        [SerializeField] private int countOfWaves;

        protected override Sequence GetSequence()
        {
            DOTween.Kill(this);

            root.localScale = startScale;
            root.localPosition = startPos;

            var seq = DOTween.Sequence(this).SetUpdate(true)
               .Append(root.DOScale(maxScale, duration1))
               .Join(root.DOLocalMove(maxPos, duration1));

            for (int i = 0; i < countOfWaves; i++)
            {
                seq
                .Append(root.DOScale(endScale, duration2))
                .Join(root.DOLocalMove(endPos, duration2))

               .Append(root.DOScale(maxScale, duration2))
               .Join(root.DOLocalMove(maxPos, duration2));
            }

            seq
            .Append(root.DOScale(endScale, duration2))
            .Join(root.DOLocalMove(endPos, duration2))
             ;
            return seq;

        }

        protected override void ResetToDefault()
        {
            root.localScale = startScale;
            root.localPosition = startPos;
        }
    }
}
