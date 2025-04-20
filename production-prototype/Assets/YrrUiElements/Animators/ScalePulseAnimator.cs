using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ScalePulseAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private int countOfPulsing;
        [SerializeField] private float tickTime;
        [SerializeField] private float delayTime;
        [SerializeField] private float maxScaleValue;

        protected override Sequence GetSequence()
        {
            var seq = DOTween.Sequence(this).SetUpdate(true);
            for (int i = 0; i < countOfPulsing; i++)
            {
                seq
                .Append(root.DOScale(maxScaleValue, tickTime))
                .Append(root.DOScale(1f, tickTime));
            }
            seq.AppendInterval(delayTime);
            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localScale = Vector3.one;
        }
    }
}
