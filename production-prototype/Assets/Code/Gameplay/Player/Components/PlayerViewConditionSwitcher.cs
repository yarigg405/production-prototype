using UnityEngine;
using UnityEngine.AI;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Player.Components
{
    internal sealed class PlayerViewConditionSwitcher : ITickable
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private PlayerViewModel _viewModel;

        public PlayerViewConditionSwitcher(PlayerViewModel viewModel, NavMeshAgent agent)
        {
            _viewModel = viewModel;
            _agent = agent;
        }

        private Vector3 _lastPosition;

        void ITickable.Tick()
        {
            var currentPosition = _agent.transform.position;
            _viewModel.IsMoving.SetValue(currentPosition != _lastPosition);

            _lastPosition = currentPosition;
        }
    }
}
