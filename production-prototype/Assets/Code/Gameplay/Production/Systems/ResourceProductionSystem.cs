using UnityEngine;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Production.Systems
{
    internal sealed class ResourceProductionSystem : ITickable
    {
        private readonly ProductionBuildingContainer _buildingsContainer;
        private readonly BuildingModelsContainer _modelsContainer;

        public ResourceProductionSystem(
            ProductionBuildingContainer buildingContainer,
            BuildingModelsContainer buildingModelsContainer)
        {
            _buildingsContainer = buildingContainer;
            _modelsContainer = buildingModelsContainer;
        }

        void ITickable.Tick()
        {
            var dt = Time.deltaTime;
            foreach (var building in _buildingsContainer.Buildings)
            {
                var model = _modelsContainer.GetModel(building.UniqId);
                model.IncreaseTimer(dt);

                if (model.CurrentProductionTimer >= building.Config.ProductionTickTime)
                {
                    model.IncreaseProduction(building.Config.ResourcesCountPerTick);
                }
            }
        }
    }
}
