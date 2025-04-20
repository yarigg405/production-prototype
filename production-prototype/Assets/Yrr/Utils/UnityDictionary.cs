using System;
using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Utils
{
    [Serializable]
    public struct UnityDictionary<TKey, TValue>
    {
        [SerializeField] private List<UnityKeyValuePair<TKey, TValue>> data;
        private Dictionary<TKey, int> _indexes;

        public TValue Get(TKey key)
        {
            if (_indexes == null)
                Initialize();

            if (_indexes.TryGetValue(key, out var index))
                return data[index].Value;

            Debug.Log("Item is not found: " + key.ToString());
            return default;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            if (_indexes.TryGetValue(key, out var index))
            {
                value = data[index].Value;
                return true;
            }

            else
            {
                value = default;
                return false;
            }
        }

        private void Initialize()
        {
            _indexes = new Dictionary<TKey, int>();
            for (int i = 0; i < data.Count; i++)
            {
                try
                {
                    _indexes.Add(data[i].Key, i);
                }

                catch
                {
                    Debug.LogError($"Item {data[i].Key} has already been added");
                }
            }
        }
    }

    [Serializable]
    public struct UnityKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}
