using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Yrr.Utils
{
    public sealed class RandomizerByWeight<T>
    {
        private readonly List<ItemWithWeight<T>> _items = new();

        public int Count => _items.Count;

        public T GetRandom()
        {
            if (_items.Count == 0)
                return default;

            var totalChance = _items.Sum(x => x.ChanceWeight);
            var rand = Random.Range(0f, totalChance);
            var curChance = 0f;

            foreach (var item in _items)
            {
                curChance += item.ChanceWeight;
                if (rand <= curChance)
                {
                    return item.Value;
                }
            }

            return _items.Last().Value;
        }

        public void AddVariant(T item, float chanceWeight)
        {
            _items.Add(new ItemWithWeight<T>(item, chanceWeight));
        }

        public void Clear()
        {
            _items.Clear();
        }
    }

    internal sealed class ItemWithWeight<T>
    {
        public T Value { get; }
        public float ChanceWeight { get; }

        public ItemWithWeight(T item, float chanceWeight)
        {
            Value = item;
            ChanceWeight = chanceWeight;
        }
    }
}
