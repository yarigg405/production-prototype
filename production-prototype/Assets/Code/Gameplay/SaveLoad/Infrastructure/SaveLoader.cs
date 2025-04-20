using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad.Infrastructure
{
    internal abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        void ISaveLoader.LoadGame(IGameRepository repository, IObjectResolver resolver)
        {
            var service = resolver.Resolve<TService>();
            var data = repository.GetData<TData>();

            LoadService(service, data);
        }

        void ISaveLoader.SaveGame(IGameRepository repository, IObjectResolver resolver)
        {
            var service = resolver.Resolve<TService>();
            var data = ConvertToSaveData(service);
            repository.SetData(data);
        }


        protected abstract TData ConvertToSaveData(TService service);

        protected abstract void LoadService(TService service, TData data);
    }
}
