using Game.Assets.Code.Gameplay.Gathering;
using Game.Assets.Code.Gameplay.ProductionResources;
using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;
using System.Collections.Generic;


namespace Game.Assets.Code.Gameplay.SaveLoad.SaveLoaders
{
    internal sealed class ResourcesStorageSaveLoader : MetaSaveLoader<Dictionary<ResourceType, int>, PlayerResourcesStorage>
    {
        protected override Dictionary<ResourceType, int> ConvertToSaveData(PlayerResourcesStorage service)
        {
            return service.GetStoredData();
        }

        protected override void LoadService(PlayerResourcesStorage service, Dictionary<ResourceType, int> data)
        {
            service.Setup(data);
        }
    }
}
