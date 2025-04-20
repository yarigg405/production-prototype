using Game.Assets.Code.Gameplay.Player.Components;
using UnityEngine;
using UnityEngine.AI;
using VContainer;
using VContainer.Unity;


namespace Game
{
    public sealed class PlayerLifetimeScope : LifetimeScope
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        [SerializeField] private PlayerViewModel _viewModel = new();

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_agent);
            builder.RegisterInstance(_animator);
            builder.RegisterInstance(_viewModel);

            builder.Register<PlayerViewConditionSwitcher>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
            builder.Register<PlayerAnimatorController>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
        }
    }
}
