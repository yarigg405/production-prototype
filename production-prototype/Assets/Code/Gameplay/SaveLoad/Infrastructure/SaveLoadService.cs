using System.Collections.Generic;
using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad.Infrastructure
{
    internal abstract class SaveLoadService<TSaveLoader> where TSaveLoader : ISaveLoader
    {
        private readonly IEnumerable<TSaveLoader> _saveLoaders;
        private readonly IGameRepository _repository;
        private readonly IObjectResolver _resolver;

        protected abstract string SavePath { get; }

        public SaveLoadService(
            IEnumerable<TSaveLoader> saveLoaders,
            IGameRepository gameRepository,
            IObjectResolver resolver)
        {
            _saveLoaders = saveLoaders;
            _repository = gameRepository;
            _resolver = resolver;
        }

        public void Save()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_repository, _resolver);
                _repository.SaveState(SavePath);
            }
        }

        public void Load()
        {
            _repository.LoadState(SavePath);
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_repository, _resolver);
            } 
        }
    }
}
