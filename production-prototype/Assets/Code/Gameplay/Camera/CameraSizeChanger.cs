using Lean.Touch;
using Unity.Cinemachine;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.Camera
{
    public class CameraSizeChanger : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private LeanPinchCamera _pinch;

        private void LateUpdate()
        {
            _cinemachineCamera.Lens.OrthographicSize = _pinch.Zoom;
        }
    }
}