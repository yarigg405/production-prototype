using DG.Tweening;
using System;
using UnityEngine;


namespace Yrr.UI.Animators
{
    public abstract class TweenAnimator : MonoBehaviour
    {
        [SerializeField] private bool playOnEnable;
        [SerializeField] private bool loop;
        private TweenCallback _callback;


        private void OnEnable()
        {
            if (loop)
            {
                _callback = Animate;
            }

            if (playOnEnable)
            {
                Animate();
            }
        }

        private void OnDisable()
        {
            StopAnimation();
        }

        [ContextMenu("Animate")]
        public void Animate()
        {
            var seq = GetSequence();
            if (_callback != null)
                seq.AppendCallback(_callback);
        }

        public void StopAnimation()
        {
            DOTween.Kill(this);
            ResetToDefault();
        }

        public void SetCallback(Action callback)
        {
            _callback = () => callback();
        }

        protected abstract Sequence GetSequence();

        protected abstract void ResetToDefault();

        public Sequence GetSequenceForComposite()
        {
            return GetSequence();
        }

    }
}