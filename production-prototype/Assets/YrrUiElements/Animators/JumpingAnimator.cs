using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class JumpingAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float jumpPower = 20f;
        [SerializeField] private int countOfJumps;
        [SerializeField] private float jumpTime;
        [SerializeField] private float delayTime;


        protected override Sequence GetSequence()
        {
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOLocalJump(Vector3.zero, jumpPower, countOfJumps, jumpTime))
                .AppendInterval(delayTime)
            ;

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localPosition = Vector3.zero;
        }
    }
}
