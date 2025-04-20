using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ShowWithScaleAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float startScale = 0f;
        [SerializeField] private float maxScale = 1.2f;
        [SerializeField] private float endScale = 1f;
        [SerializeField] private float duration1;
        [SerializeField] private float duration2;

        protected override Sequence GetSequence()
        {
            DOTween.Kill(this);
            root.localScale = Vector3.one * startScale;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOScale(maxScale, duration1))
                .Append(root.DOScale(endScale, duration2));

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localScale = Vector3.one * startScale;
        }
    }
}
