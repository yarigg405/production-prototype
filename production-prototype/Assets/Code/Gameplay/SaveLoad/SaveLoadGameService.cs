using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;
using System.Collections.Generic;
using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad
{
    internal sealed class SaveLoadGameService : SaveLoadService<IGameSaveLoader>
    {
        public SaveLoadGameService(IEnumerable<IGameSaveLoader> saveLoaders,
            IGameRepository gameRepository,
            IObjectResolver resolver)
            : base(saveLoaders, gameRepository, resolver) { }

        protected override string SavePath => "SaveDataGame_" + _sceneName;
        private string _sceneName;


        internal void SetSceneName(string sceneName)
        {
            _sceneName = sceneName;
        }
    }
}
