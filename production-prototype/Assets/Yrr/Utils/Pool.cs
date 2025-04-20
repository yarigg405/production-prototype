using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Utils
{
    public class Pool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;
        [SerializeField] private Transform objectsInPoolContainer;
        [SerializeField] private int initializeCount = 10;

        private readonly Queue<T> _pooledObjects = new();

        private void Awake()
        {
            InitializePool(prefab, initializeCount);
        }

        private void InitializePool(T prefab, int initialCount)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, objectsInPoolContainer);
                _pooledObjects.Enqueue(bullet);
            }
        }

        public T SpawnObject(Transform parentForNewObject = null)
        {
            if (_pooledObjects.TryDequeue(out var newObject))
            {
                newObject.transform.SetParent(parentForNewObject);
            }
            else
            {
                newObject = Instantiate(prefab, parentForNewObject);
            }

            return newObject;
        }

        public void DespawnObject(T poolableObject)
        {
            _pooledObjects.Enqueue(poolableObject);
            poolableObject.transform.SetParent(objectsInPoolContainer);
        }

        public IEnumerable<T> GetPooledObjects()
        {
            return _pooledObjects;
        }
    }
}
