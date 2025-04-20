using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class FadeAlphaAnimator : TweenAnimator
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private float startAlpha;
        [SerializeField] private float endAlpha;
        [SerializeField] private float duration;

        protected override Sequence GetSequence()
        {
            canvasGroup.alpha = startAlpha;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, endAlpha, duration))
                ;

            return seq;
        }

        protected override void ResetToDefault()
        {
            canvasGroup.alpha = startAlpha;
        }
    }
}
