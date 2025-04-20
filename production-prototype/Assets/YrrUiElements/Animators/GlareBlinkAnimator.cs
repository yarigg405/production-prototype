using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class GlareBlinkAnimator : TweenAnimator
    {
        [SerializeField] private Transform movingRoot;
        [SerializeField] private int blinkCount = 1;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private float duration;
        [SerializeField] private float delay;


        protected override Sequence GetSequence()
        {
            movingRoot.localPosition = startPosition;
            var seq = DOTween.Sequence(this).SetUpdate(true);

            for (int i = 0; i < blinkCount; i++)
            {
                seq
                    .Append(movingRoot.DOLocalMove(endPosition, duration))
                    .Append(movingRoot.DOLocalMove(startPosition, 0))
                    ;
            }
            seq.AppendInterval(delay);

            return seq;
        }

        protected override void ResetToDefault()
        {
            movingRoot.localPosition = startPosition;
        }
    }
}
