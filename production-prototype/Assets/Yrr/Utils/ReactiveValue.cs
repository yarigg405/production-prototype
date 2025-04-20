using System;
using UnityEngine;


namespace Yrr.Utils
{
    [Serializable]
    public struct ReactiveValue<T>
    {
        public event Action<T> OnChange;

        [SerializeField]
#if UNITY_EDITOR
        [ReadOnly]
#endif
        private T _currentValue;

        public T Value
        {
            get => _currentValue;
            set => SetValue(value);
        }


        public void SetValue(T value)
        {
            if (value.Equals(_currentValue)) return;

            _currentValue = value;
            OnChange?.Invoke(_currentValue);
        }

        public void Cleanup()
        {
            OnChange = null;
        }


        public static implicit operator T(ReactiveValue<T> value)
        {
            return value.Value;
        }



        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
