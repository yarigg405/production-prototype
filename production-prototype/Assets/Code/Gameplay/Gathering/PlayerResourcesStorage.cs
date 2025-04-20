using Game.Assets.Code.Gameplay.ProductionResources;
using System;
using System.Collections.Generic;
using Yrr.Audio;


namespace Game.Assets.Code.Gameplay.Gathering
{
    internal sealed class PlayerResourcesStorage
    {
        private Dictionary<ResourceType, int> _resourcesCount = new();

        public event Action<ResourceType, int> ResourceCountChanged;

        public void AddResource(ResourceType resourceType, int count)
        {
            if (!_resourcesCount.ContainsKey(resourceType))
            {
                _resourcesCount[resourceType] = count;
                ResourceCountChanged?.Invoke(resourceType, _resourcesCount[resourceType]);
            }
            else
            {
                _resourcesCount[resourceType] += count;
                ResourceCountChanged?.Invoke(resourceType, _resourcesCount[resourceType]);
                AudioManager.Instance.PlayUiSound("coin");
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
