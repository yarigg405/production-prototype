using UnityEngine;
using Game.Assets.Code.Gameplay.Player;
using Game.Assets.Code.Gameplay.Production.Buildings;
using VContainer.Unity;
using Game.Assets.Code.Gameplay.Production.Systems;


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
            _buildingModelsContainer = buildingModelsContainer;
        }

        void IGatheringSystem.PlayerEnterGatheringZone(PlayerEntity player, ProductionBuilding building)
        {
            _player = player;
            _currentgatheringBuilding = building;
        }

        void IGatheringSystem.PlayerExitGatheringZone(PlayerEntity player, ProductionBuilding building)
        {
            _player = null;
            _currentgatheringBuilding = null;
        }

        void ITickable.Tick()
        {
            if (!_currentgatheringBuilding) return;
            if (!_player) return;
            if (_player.ViewModel.IsMoving) return;

            _currentGarherTimer += Time.deltaTime;
            if (_currentGarherTimer > _gatherResourceDelay)
            {
                var model = _buildingModelsContainer.GetModel(_currentgatheringBuilding.UniqId);
                var count = model.CurrentResourcesCount;
                if (count <= 0) return;

                model.ConsumeProduction(1);
                _resourcesStorage.AddResource(_currentgatheringBuilding.Config.ResourceType, count);
                _currentGarherTimer = 0;
            }
        }
    }
}
