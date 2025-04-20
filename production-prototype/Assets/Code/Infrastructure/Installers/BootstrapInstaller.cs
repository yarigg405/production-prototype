using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Game.Assets.Code.Gameplay.Level;
using Game.Assets.Code.Gameplay.Player.Factory;
using Game.Assets.Code.Gameplay.ProductionResources;
using Game.Assets.Code.Infrastructure.Loading;
using Game.Assets.Code.Infrastructure.States.GameStates;
using Game.Assets.Code.StaticData;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Game.Assets.Code.Infrastructure.Installers
{
    internal sealed class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private StaticDataContainer _staticDataContainer;
        [SerializeField] private ProductionResourcesStaticData _resourcesData;

        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;

            RegisterStaticData();
            RegisterInfrastructureServices();
            RegisterStates();
            RegisterFactories();

            RegisterEntryPoint();
        }

        private void RegisterStaticData()
        {
            _builder.RegisterInstance(_staticDataContainer);
            _builder.RegisterInstance(_resourcesData);
        }

        private void RegisterInfrastructureServices()
        {
            _builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<ScenesLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<PlayerProvider>(Lifetime.Singleton).AsSelf();
            _builder.Register<LevelDataProvider>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterStates()
        {
            _builder.Register<BootstrapState>(Lifetime.Transient).AsSelf();
            _builder.Register<LoadGameState>(Lifetime.Transient).AsSelf();
            _builder.Register<EnterGameState>(Lifetime.Transient).AsSelf();
            _builder.Register<GameLoopState>(Lifetime.Transient).AsSelf();
        }

        private void RegisterFactories()
        {
            _builder.Register<PlayerFactory>(Lifetime.Transient).AsSelf();
        }

        private void RegisterEntryPoint()
        {
            _builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
