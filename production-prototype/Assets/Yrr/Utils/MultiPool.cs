using System;
using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Utils
{
    public class MultiPool<T> : MonoBehaviour where T : Component
    {
        private readonly Dictionary<int, int> _cachedIds = new();

        private readonly Dictionary<int, Queue<T>> _pooledObjects = new();
        [SerializeField] private Transform objectsInPoolContainer;

        public event Action<T> OnNewObjectInstantiated;
        public event Action<T> OnObjectSpawned;
        public event Action<T> OnObjectDespawned;

        public void PopulateWith(T prefab, int amount)
        {
            var key = prefab.GetInstanceID();
            if (!_pooledObjects.ContainsKey(key)) _pooledObjects.Add(key, new Queue<T>());

            while (amount > 0)
            {
                var go = CreateNewObject(prefab);
                _pooledObjects[key].Enqueue(go);
                amount--;
            }
        }

        public T SpawnObject(T prefab, Transform parent)
        {
            var key = prefab.GetInstanceID();

            if (!_pooledObjects.ContainsKey(key)) _pooledObjects.Add(key, new Queue<T>());

            var queue = _pooledObjects[key];
            if (queue.TryDequeue(out var go))
            {
                go.transform.SetParent(parent);
                return go;
            }

            go = CreateNewObject(prefab);
            go.transform.SetParent(parent);

            OnObjectSpawned?.Invoke(go);

            go.gameObject.SetActive(true);
            return go;
        }

        public void DespawnObject(T poolableObject)
        {
            if (_cachedIds.TryGetValue(poolableObject.GetInstanceID(), out var prefabId))
            {
                _pooledObjects[prefabId].Enqueue(poolableObject);
                poolableObject.transform.SetParent(objectsInPoolContainer);
                OnObjectDespawned?.Invoke(poolableObject);
            }

            else
            {
                Debug.LogError($"Object was not added to the pool: {poolableObject.name}");
                poolableObject.gameObject.SetActive(false);
            }
        }

        private T CreateNewObject(T prefab)
        {
            var key = prefab.GetInstanceID();
            var go = Instantiate(prefab, objectsInPoolContainer);
            _cachedIds.Add(go.GetInstanceID(), key);
            OnNewObjectInstantiated?.Invoke(go);
            return go;
        }

        public IEnumerable<T> GetPooledObjects()
        {
            foreach (var pool in _pooledObjects)
            foreach (var pooled in pool.Value)
                yield return pooled;
        }

        public int GetCountOf(T prefab)
        {
            var key = prefab.GetInstanceID();
            if (_pooledObjects.TryGetValue(key, out var queue))
                return queue.Count;

            return 0;
        }
    }
}