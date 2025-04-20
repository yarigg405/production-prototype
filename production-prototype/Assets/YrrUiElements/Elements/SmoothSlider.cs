using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Yrr.UI.Elements
{
    public sealed class SmoothSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private bool onlyIncrement;
        [SerializeField] private float speedModifier = 1f;

        private float _targetValue;
        private bool _isMoving;

        public UnityEvent OnSliderMoveUp;
        public UnityEvent OnSliderMoveDown;
        public UnityEvent OnSliderStop;
        public UnityEvent OnSliderMaxReached;

        private void Update()
        {
            if (slider.value.Equals(_targetValue)) return;

            if (!_isMoving)
            {
                if (_targetValue > slider.value)
                    OnSliderMoveUp?.Invoke();

                else
                    OnSliderMoveDown?.Invoke();
                _isMoving = true;
            }

            var delta = Mathf.Abs(slider.value - _targetValue) * 2;
            if (delta < 0.45) delta = 0.45f;
            slider.value = Mathf.MoveTowards(slider.value, _targetValue, delta * Time.unscaledDeltaTime * speedModifier);

            if (!slider.value.Equals(_targetValue)) return;
            _isMoving = false;
            OnSliderStop?.Invoke();

            if (slider.value == 1)
                OnSliderMaxReached?.Invoke();
        }



        /// <summary>
        /// Value must be in range 0-1
        /// </summary>
        /// <param name="value"></param>
        public void InitValue(float value)
        {
            if (value < 0)
            {
                value = 0;
                Debug.LogWarning("Value must be 0..1");
            }
            if (value > 1)
            {
                value = 1;
                Debug.LogWarning("Value must be 0..1");
            }

            _targetValue = value;
            slider.value = value;
        }

        /// <summary>
        /// Value must be in range 0-1
        /// </summary>
        /// <param name="value"></param>
        public void ChangeValue(float value)
        {
            if (value < 0)
            {
                value = 0;
                Debug.LogWarning("Value must be 0..1");
            }
            if (value > 1)
            {
                value = 1;
                Debug.LogWarning("Value must be 0..1");
            }

            if (onlyIncrement && value == 1)
            {
                OnSliderStop.AddListener(ResetSlider);
            }

            if (value < _targetValue && onlyIncrement)
            {
                _targetValue = 1;
            }
            else
            {
                _targetValue = value;
            }
        }

        private void ResetSlider()
        {
            _targetValue = 0;
            OnSliderStop.RemoveListener(ResetSlider);
        }
    }
}