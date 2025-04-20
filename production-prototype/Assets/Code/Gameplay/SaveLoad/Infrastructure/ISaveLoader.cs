using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad.Infrastructure
{
    internal interface ISaveLoader
    {
        void SaveGame(IGameRepository repository, IObjectResolver resolver);
        void LoadGame(IGameRepository repository, IObjectResolver resolver);
    }
}
