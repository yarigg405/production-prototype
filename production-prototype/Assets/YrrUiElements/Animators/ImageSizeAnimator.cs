using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ImageSizeAnimator : TweenAnimator
    {
        [SerializeField] private RectTransform root;

        [SerializeField] private Vector2 startSize;
        [SerializeField] private Vector2 finishSize;
        [SerializeField] private float duration;



        protected override Sequence GetSequence()
        {
            root.sizeDelta = startSize;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(DOTween.To(() => root.sizeDelta, x => root.sizeDelta = x, finishSize, duration))
                ;
            return seq;
        }

        protected override void ResetToDefault()
        {
            root.sizeDelta = startSize;
        }

        [ContextMenu("SetStartSize")]
        private void SetStartSize()
        {
            startSize = root.sizeDelta;
        }

        [ContextMenu("SetFinishSize")]
        private void SetFinishSize()
        {
            finishSize = root.sizeDelta;
        }
    }
}
