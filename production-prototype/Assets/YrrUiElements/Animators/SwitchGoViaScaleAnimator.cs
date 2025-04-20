using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class SwitchGoViaScaleAnimator : TweenAnimator
    {
        [SerializeField] private GameObject switchFrom;
        [SerializeField] private GameObject switchTo;
        [SerializeField] private float startScale = 1f;
        [SerializeField] private float minScale = 0f;
        [SerializeField] private float durationDown = 0.25f;
        [SerializeField] private float durationUp = 0.25f;


        protected override Sequence GetSequence()
        {
            switchFrom.SetActive(true);
            switchTo.SetActive(false);

            switchFrom.transform.localScale = startScale * Vector3.one;
            switchTo.transform.localScale = minScale * Vector3.one;

            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(switchFrom.transform.DOScale(minScale, durationDown))
                .AppendCallback(() =>
                {
                    switchTo.SetActive(true);
                    switchFrom.SetActive(false);
                })
                .Append(switchTo.transform.DOScale(startScale, durationUp))
                ;
            return seq;
        }

        protected override void ResetToDefault()
        {
            switchFrom.SetActive(true);
            switchTo.SetActive(false);

            switchFrom.transform.localScale = startScale * Vector3.one;
            switchTo.transform.localScale = startScale * Vector3.one;
        }
    }
}