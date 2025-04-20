using Assets.Code.Infrastructure.DI;
using Game.Assets.Code.Gameplay.Level;
using Game.Assets.Code.Gameplay.Player.Systems;
using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSpawnPosition _spawnPosition;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_spawnPosition);
            builder.Register<PlayerNavigationSystem>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
