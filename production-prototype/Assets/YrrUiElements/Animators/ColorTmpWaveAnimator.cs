using DG.Tweening;
using TMPro;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ColorTmpWaveAnimator : TweenAnimator
    {
        [SerializeField] private TextMeshProUGUI colorableText;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;
        [SerializeField] private bool needReturn;

        [SerializeField] private float duration;

        protected override Sequence GetSequence()
        {
            colorableText.color = startColor;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(DOVirtual.Color(startColor, endColor, duration, (value) =>
                {
                    colorableText.color = value;
                }));

            if(needReturn)
                seq.Append(DOVirtual.Color(endColor, startColor, duration, (value) =>
                {
                    colorableText.color = value;
                }));

            return seq;
        }

        protected override void ResetToDefault()
        {
            colorableText.color = startColor;
        }
    }
}