using Assets.Code.Infrastructure.DI;
using Game.Assets.Code.Gameplay.Level;
using Game.Assets.Code.Gameplay.Player.Systems;
using Game.Assets.Code.Gameplay.Production.Systems;
using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSpawnPosition _spawnPosition;
        [SerializeField] private ProductionBuildingContainer _productionBuildingContainer;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_spawnPosition);
            builder.Register<PlayerNavigationSystem>(Lifetime.Scoped).AsImplementedInterfaces();

            builder.RegisterInstance(_productionBuildingContainer);
            builder.Register<BuildingModelsContainer>(Lifetime.Scoped).AsSelf();
            builder.Register<ResourceProductionSystem>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<UpdateProductionWidgetsSystem>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
