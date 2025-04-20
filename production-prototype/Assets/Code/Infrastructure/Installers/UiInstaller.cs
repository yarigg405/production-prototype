using Assets.Code.Infrastructure.DI;
using UnityEngine;
using VContainer;
using Yrr.UI;


namespace Game.Assets.Code.Infrastructure.Installers
{
    internal sealed class UiInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManager;
      //  [SerializeField] private 

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_uiManager);
        }
    }
}
