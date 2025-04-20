using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class CompositeAnimator : TweenAnimator
    {
        [SerializeField] private TweenAnimator[] animators;

        protected override Sequence GetSequence()
        {
            var seq = DOTween.Sequence(this).SetUpdate(true);

            foreach (var anim in animators)
            {
                seq.Join(anim.GetSequenceForComposite());
            }

            return seq;
        }

        protected override void ResetToDefault()
        {
            foreach (var anim in animators)
            {
                anim.StopAnimation();
            }
        }
    }
}
