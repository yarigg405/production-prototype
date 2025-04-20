using TMPro;
using UnityEngine;
using Yrr.Utils;


namespace Yrr.UI.Elements
{
    public sealed class TickableText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;
        [SerializeField] private bool shortMoney;
        [SerializeField] private float tickSpeedModifier = 8f;
        private string _prefix;
        private string _postfix;
        private float _targetCounter;
        private float _counter;


        private void Update()
        {
            if (_targetCounter.Equals(_counter)) return;

            var delta = Mathf.Abs(_targetCounter - _counter) * tickSpeedModifier;
            if (delta < 10) delta = 10;

            _counter = Mathf.MoveTowards(_counter, _targetCounter, delta * Time.unscaledDeltaTime);
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (shortMoney)
            {
                tmp.text = $"{_prefix}{_counter.ToShortMoneyString()}{_postfix}";
            }

            else
            {
                tmp.text = $"{_prefix}{_counter.ToIntString()}{_postfix}";
            }
        }

        public void InitValue(ulong value)
        {
            _targetCounter = value;
            _counter = value;
            UpdateVisual();
        }

        public void SmoothChangeValue(ulong value)
        {
            _targetCounter = value;
        }

        public void SetPrefix(string prefix)
        {
            _prefix = prefix;
        }

        public void SetPostfix(string postfix)
        {
            _postfix = postfix;
        }
    }
}
