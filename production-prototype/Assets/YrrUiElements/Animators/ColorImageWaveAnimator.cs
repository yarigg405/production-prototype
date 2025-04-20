using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace Yrr.UI.Animators
{
    internal sealed class ColorImageWaveAnimator : TweenAnimator
    {
        [SerializeField] private Image colorableImage;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;
        [SerializeField] private bool needReturn;

        [SerializeField] private float duration;

        protected override Sequence GetSequence()
        {
            colorableImage.color = startColor;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(DOVirtual.Color(startColor, endColor, duration, (value) =>
                {
                    colorableImage.color = value;
                }));
            if (needReturn)
                seq
                .Append(DOVirtual.Color(endColor, startColor, duration, (value) =>
                {
                    colorableImage.color = value;
                }));

            return seq;
        }

        protected override void ResetToDefault()
        {
            colorableImage.color = startColor;
        }
    }
}