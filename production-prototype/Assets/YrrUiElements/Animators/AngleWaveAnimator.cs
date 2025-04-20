using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class AngleWaveAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float maxAngle;
        [SerializeField] private float waveDuration;
        [SerializeField] private int wavesCount;
        [SerializeField] private float animationDelay;

        protected override Sequence GetSequence()
        {
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOLocalRotate(new Vector3(0, 0, -maxAngle), waveDuration / 2f));
            for (int i = 0; i < wavesCount; i++)
            {
                seq
                    .Append(root.DOLocalRotate(new Vector3(0, 0, maxAngle), waveDuration))
                    .Append(root.DOLocalRotate(new Vector3(0, 0, -maxAngle), waveDuration));
            }
            seq
                .Append(root.DOLocalRotate(new Vector3(0, 0, 0), waveDuration / 2f))
                .AppendInterval(animationDelay);

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.transform.localRotation = Quaternion.identity;
        }
    }
}
