using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ColorSpriteRendererWaveAnimator : TweenAnimator
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;

        [SerializeField] private float duration;

        protected override Sequence GetSequence()
        {
            spriteRenderer.color = startColor;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(DOVirtual.Color(startColor, endColor, duration, (value) =>
                {
                    spriteRenderer.color = value;
                }))
                .Append(DOVirtual.Color(endColor, startColor, duration, (value) =>
                {
                    spriteRenderer.color = value;
                }));

            return seq;
        }

        protected override void ResetToDefault()
        {
            spriteRenderer.color = startColor;
        }
    }
}
