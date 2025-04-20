using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class MoveOutAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [Space]
        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 endPos;
        [Space]
        [SerializeField] private Vector3 startScale;
        [SerializeField] private Vector3 endScale;
        [Space]
        [SerializeField] private float duration;



        protected override Sequence GetSequence()
        {
            root.localPosition = startPos;
            root.localScale = startScale;

            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOLocalMove(endPos, duration))
                .Join(root.DOScale(endScale, duration))
                ;

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localPosition = endPos;
            root.localScale = endScale;
        }


        [ContextMenu("SetStartPos")]
        public void SetStartPos()
        {
            startPos = transform.localPosition;
        }

        [ContextMenu("SetEndPos")]
        public void SetEndPos()
        {
            endPos = transform.localPosition;
        }
    }
}
