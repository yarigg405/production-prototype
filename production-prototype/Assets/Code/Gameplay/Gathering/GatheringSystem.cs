using Cheats;
using Game.Assets.Code.Gameplay.Player;
using Game.Assets.Code.Gameplay.Production.Buildings;
using Game.Assets.Code.Gameplay.Production.Systems;
using UnityEngine;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Gathering
{
    internal sealed class GatheringSystem : IGatheringSystem, ITickable
    {
        private readonly PlayerResourcesStorage _resourcesStorage;
        private readonly BuildingModelsContainer _buildingModelsContainer;

        private const float _gatherResourceDelay = 0.2f;
        private float _currentGarherTimer = 0f;

        private PlayerEntity _player;
        private ProductionBuilding _currentgatheringBuilding;

        public GatheringSystem(PlayerResourcesStorage resourcesStorage, BuildingModelsContainer buildingModelsContainer)
        {
            _resourcesStorage = resourcesStorage;
            CheatConsoleController.Init(_resourcesStorage);
            _buildingModelsContainer = buildingModelsContainer;
        }

        void IGatheringSystem.PlayerEnterGatheringZone(PlayerEntity player, ProductionBuilding building)
        {
            _player = player;
            _currentgatheringBuilding = building;
        }

        void IGatheringSystem.PlayerExitGatheringZone(PlayerEntity player, ProductionBuilding building)
        {
            _player.ViewModel.IsInInteraction.Value = false;
            _player = null;
            _currentgatheringBuilding = null;
        }

        void ITickable.Tick()
        {
            if (!_currentgatheringBuilding) return;
            if (!_player) return;
            if (_player.ViewModel.IsMoving)
            {
                _player.ViewModel.IsInInteraction.Value = false;
                return;
            }

            _player.ViewModel.IsInInteraction.Value = true;
            _currentGarherTimer += Time.deltaTime;
            if (_currentGarherTimer > _gatherResourceDelay)
            {
                var model = _buildingModelsContainer.GetModel(_currentgatheringBuilding.UniqId);
                var count = model.CurrentResourcesCount;
                if (count <= 0 || (_currentgatheringBuilding.Config.ResourcesCountLimit == count && _currentgatheringBuilding.Config.ResourcesCountLimit != 0)) return;

                model.ConsumeProduction(1);

                _resourcesStorage.AddResource(_currentgatheringBuilding.Config.ResourceType, _currentgatheringBuilding.IsUsingMode ? 2 : 1);
                _currentGarherTimer = 0;
            }
        }
    }
}
