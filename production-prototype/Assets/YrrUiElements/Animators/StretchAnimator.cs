using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class StretchAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private Vector3 startPositon;
        [SerializeField] private Vector3 endPositon;
        [SerializeField] private Vector3 startScale;
        [SerializeField] private Vector3 endScale;
        [SerializeField] private float duration;

        protected override Sequence GetSequence()
        {
            root.localPosition = startPositon;
            root.localScale = startScale;

            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOScale(endScale, duration))
                .Join(root.DOLocalMove(endPositon, duration))

                .Append(root.DOScale(startScale, duration))
                .Join(root.DOLocalMove(startPositon, duration))
                ;

            return seq;
        }

        [ContextMenu("SetStart")]
        private void SetStart()
        {
            startPositon = root.localPosition;
            startScale = root.localScale;
        }

        [ContextMenu("SetEnd")]
        private void SetEnd()
        {
            endPositon = root.localPosition;
            endScale = root.localScale;
        }

        protected override void ResetToDefault()
        {
            root.localPosition = startPositon;
            root.localScale = startScale;
        }
    }
}
