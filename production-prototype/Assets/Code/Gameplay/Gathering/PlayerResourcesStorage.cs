using Game.Assets.Code.Gameplay.ProductionResources;
using System;
using System.Collections.Generic;


namespace Game.Assets.Code.Gameplay.Gathering
{
    internal sealed class PlayerResourcesStorage
    {
        private Dictionary<ResourceType, int> _resourcesCount = new();

        public event Action<ResourceType> ResourceAddedFirstTime;
        public event Action<ResourceType, int> ResourceCountChanged;

        public void AddResource(ResourceType resourceType, int count)
        {
            if (!_resourcesCount.ContainsKey(resourceType))
            {
                _resourcesCount[resourceType] = count;
                ResourceAddedFirstTime?.Invoke(resourceType);
            }
            else
            {
                _resourcesCount[resourceType] += count;
                ResourceCountChanged?.Invoke(resourceType, count);
            }
        }

        internal void Setup(Dictionary<ResourceType, int> resourcesCount)
        {
            _resourcesCount = resourcesCount;
        }

        internal Dictionary<ResourceType, int> GetStoredData()
        {
            return _resourcesCount;
        }
    }
}
