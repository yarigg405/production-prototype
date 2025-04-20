using System;
using UnityEngine;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Player.Components
{
    internal sealed class PlayerAnimatorController : IStartable, IDisposable
    {
        private readonly Animator _animator;
        private readonly PlayerViewModel _viewModel;

        public PlayerAnimatorController(Animator animator, PlayerViewModel viewModel)
        {
            _animator = animator;
            _viewModel = viewModel;
        }

        private const string _moveState = "run";
        private const string _interactionState = "interaction";


        void IStartable.Start()
        {
            _viewModel.IsMoving.OnChange += OnMovingChangedHandler;
            _viewModel.IsInInteraction.OnChange += OnInteractionChangedHandler;
        }

        void IDisposable.Dispose()
        {
            _viewModel.IsMoving.OnChange -= OnMovingChangedHandler;
            _viewModel.IsInInteraction.OnChange -= OnInteractionChangedHandler;
        }

        private void OnMovingChangedHandler(bool moving)
        {
            _animator.SetBool(_moveState, moving);
        }

        private void OnInteractionChangedHandler(bool interaction)
        {
            _animator.SetBool(_interactionState, interaction);
        }
    }
}
