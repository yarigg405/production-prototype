using Game.Assets.Code.Gameplay.Player.Factory;
using Lean.Touch;
using System;
using UnityEngine;
using UnityEngine.AI;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Player.Systems
{
    internal sealed class PlayerNavigationSystem : IStartable, IDisposable
    {
        private readonly PlayerProvider _playerProvider;
        private readonly LeanFingerTap _tap;

        private NavMeshAgent _agent;

        public PlayerNavigationSystem(PlayerProvider playerProvider, LeanFingerTap tap)
        {
            _playerProvider = playerProvider;
            _tap = tap;
        }

        void IStartable.Start()
        {
            _agent = _playerProvider.Player.NavMeshAgent;
            _tap.OnWorld.AddListener(OnTapHandler);
        }

        private void OnTapHandler(Vector3 tapPosition)
        {
            _agent.SetDestination(tapPosition);
        }

        void IDisposable.Dispose()
        {
            _tap.OnWorld.RemoveListener(OnTapHandler);
        }
    }
}
