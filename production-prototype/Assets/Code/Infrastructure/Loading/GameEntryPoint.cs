using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using VContainer.Unity;


namespace Game.Assets.Code.Infrastructure.Loading
{
    internal sealed class GameEntryPoint : IStartable
    {
        private readonly IStateMachine _stateMachine;

        public GameEntryPoint(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        void IStartable.Start()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
