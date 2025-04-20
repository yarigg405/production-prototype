using Game.Assets.Code.Gameplay.Production.Buildings;
using System.Collections.Generic;


namespace Game.Assets.Code.Gameplay.Production.Systems
{
    internal sealed class BuildingModelsContainer
    {
        private Dictionary<string, ProductionBuildingModel> _modelsMap = new();

        internal ProductionBuildingModel GetModel(string uniqId)
        {
            if (!_modelsMap.ContainsKey(uniqId))
            {
                _modelsMap[uniqId] = new ProductionBuildingModel(uniqId);
            }

            return _modelsMap[uniqId];
        }
    }
}
