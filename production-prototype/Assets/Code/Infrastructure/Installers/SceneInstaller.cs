using Assets.Code.Infrastructure.DI;
using Game.Assets.Code.Gameplay.Level;
using Game.Assets.Code.Gameplay.Player.Systems;
using Game.Assets.Code.Gameplay.Production.Systems;
using Game.Assets.Code.Gameplay.SaveLoad;
using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;
using Game.Assets.Code.Gameplay.SaveLoad.SaveLoaders;
using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSpawnPosition _spawnPosition;
        [SerializeField] private ProductionBuildingContainer _productionBuildingContainer;

        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;

            RegisterLevelComponents();
            RegisterSystems();
            RegisterSaveLoaders();
        }

        private void RegisterLevelComponents()
        {
            _builder.RegisterInstance(_spawnPosition);
            _builder.RegisterInstance(_productionBuildingContainer);
        }

        private void RegisterSystems()
        {
            _builder.Register<BuildingModelsContainer>(Lifetime.Scoped).AsSelf();
            _builder.Register<PlayerNavigationSystem>(Lifetime.Scoped).AsImplementedInterfaces();
            _builder.Register<ResourceProductionSystem>(Lifetime.Scoped).AsImplementedInterfaces();
            _builder.Register<UpdateProductionWidgetsSystem>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void RegisterSaveLoaders()
        {
            _builder.Register<BuildingsConditionSaveLoader>(Lifetime.Scoped).As<IGameSaveLoader>();

            _builder.Register<SaveLoadGameService>(Lifetime.Scoped).AsSelf();
        }
    }
}
