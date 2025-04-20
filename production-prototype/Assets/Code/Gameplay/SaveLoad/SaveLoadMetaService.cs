using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;
using System.Collections.Generic;
using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad
{
    internal sealed class SaveLoadMetaService : SaveLoadService<IMetaSaveLoader>
    {
        public SaveLoadMetaService(IEnumerable<IMetaSaveLoader> saveLoaders,
            IGameRepository gameRepository,
            IObjectResolver resolver)
            : base(saveLoaders, gameRepository, resolver) { }

        protected override string SavePath => "SaveDataMeta";
    }
}
