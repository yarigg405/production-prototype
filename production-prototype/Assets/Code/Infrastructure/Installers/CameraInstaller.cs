using Assets.Code.Infrastructure.DI;
using Lean.Touch;
using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Infrastructure.Installers
{
    internal sealed class CameraInstaller : MonoInstaller
    {
        [SerializeField] private LeanDragCamera _dragCamera;
        [SerializeField] private LeanPinchCamera _pinchCamera;
        [SerializeField] private LeanFingerTap _tap;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dragCamera);
            builder.RegisterInstance(_pinchCamera);
            builder.RegisterInstance(_tap);
        }
    }
}
