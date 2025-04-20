using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ScaleSpringAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float startScale = 0f;
        [SerializeField] private float maxScale = 1.1f;
        [SerializeField] private float finishScale = 1f;
        [SerializeField] private float durationUp;
        [SerializeField] private float durationDown;


        protected override Sequence GetSequence()
        {
            root.localScale = Vector3.one * startScale;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOScale(maxScale, durationUp))
                .Append(root.DOScale(finishScale, durationDown))
                ;

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localScale = Vector3.one * finishScale;
        }
    }
}
