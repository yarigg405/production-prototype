using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.DI
{
    internal sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private MonoInstaller[] _monoInstallers;
        [SerializeField] private ScriptableInstaller[] _scriptableInstallers;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var mono in _monoInstallers)
                mono.Install(builder);

            foreach (var scriptable in _scriptableInstallers)
                scriptable.Install(builder);
        }
    }
}
