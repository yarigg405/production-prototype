using Game.Assets.Code.Gameplay.Production.Buildings;
using Game.Assets.Code.Gameplay.Production.Systems;
using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;


namespace Game.Assets.Code.Gameplay.SaveLoad.SaveLoaders
{
    internal sealed class BuildingsConditionSaveLoader : GameSaveLoader<BuildingsConditionSaveData, BuildingModelsContainer>
    {
        protected override BuildingsConditionSaveData ConvertToSaveData(BuildingModelsContainer service)
        {
            return new BuildingsConditionSaveData
            {
                Models = service.GetModels()
            };
        }

        protected override void LoadService(BuildingModelsContainer service, BuildingsConditionSaveData data)
        {
            if (data.Models == null) return;

            for (int i = 0; i < data.Models.Length; i++)
            {
                var saveData = data.Models[i];
                var model = service.GetModel(saveData.UniqId);

                model.Setup(saveData.CurrentProductionTimer, saveData.CurrentResourcesCount);
            }
        }
    }

    internal struct BuildingsConditionSaveData
    {
        public ProductionBuildingModel[] Models;
    }
}
