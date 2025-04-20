using Game.Assets.Code.Gameplay.Gathering;
using Game.Assets.Code.Gameplay.ProductionResources;
using Game.Assets.Code.Gameplay.UI.Elements;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Yrr.UI;


namespace Game.Assets.Code.Gameplay.UI.Screens
{
    internal sealed class ResourcesPopupScreen : UIScreen
    {
        [SerializeField] private ResourceInStorageCell _cellPrefab;
        [SerializeField] private Transform _cellsContainer;

        private PlayerResourcesStorage _resourcesStorage;
        private ProductionResourcesStaticData _resourcesStaticData;

        [Inject]
        private void Construct(
            PlayerResourcesStorage resourcesStorage,
            ProductionResourcesStaticData resourcesStaticData)
        {
            _resourcesStaticData = resourcesStaticData;
            _resourcesStorage = resourcesStorage;
        }

        private Dictionary<ResourceType, ResourceInStorageCell> _cellsMap = new();


        protected override void OnShow(object args)
        {            
            var resources = _resourcesStorage.GetStoredData();
            foreach (var resource in resources)
            {
                if (!_cellsMap.ContainsKey(resource.Key))
                {
                    CreateNewCell(resource.Key, resource.Value);
                }

                else
                {
                    _cellsMap[resource.Key].SetupCount(resource.Value);
                }
            }
            _resourcesStorage.ResourceCountChanged += OnResourceCountChangedHandler;
        }

        private void CreateNewCell(ResourceType type, int count)
        {
            var cell = Instantiate(_cellPrefab, _cellsContainer);
            _cellsMap.Add(type, cell);

            var configData = _resourcesStaticData.ResourcesData.Get(type);
            cell.Setup(configData.Icon, configData.VisualName, count);
        }

        protected override void OnHide()
        {
            _resourcesStorage.ResourceCountChanged -= OnResourceCountChangedHandler;
        }

        private void OnResourceCountChangedHandler(ResourceType type, int count)
        {
            if (!_cellsMap.ContainsKey(type))
            {
                CreateNewCell(type, count);
            }

            else
            {
                _cellsMap[type].UpdateCount(count);
            }
        }
    }
}
