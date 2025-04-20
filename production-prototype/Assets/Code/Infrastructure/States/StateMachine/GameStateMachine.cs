using Assets.Code.Infrastructure.States.StatesInfrastructure;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.States.StateMachine
{
    internal sealed class GameStateMachine : ITickable, IStateMachine
    {
        private readonly IObjectResolver _resolver;
        private IExitableState _activeState;

        public GameStateMachine(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        void ITickable.Tick()
        {
            if (_activeState is IUpdatableState updatableState)
                updatableState.Update();
        }


        public void Enter<TState>() where TState : class, IState
        {
            var state = RequestChangeState<TState>();
            EnterState(state);
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = RequestChangeState<TState>();
            EnterPayloadState(state, payload);
        }


        private void EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);
        }

        private void EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            state.Enter();
        }

        private TState RequestChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            return GetState<TState>();
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _resolver.Resolve<TState>();
        }
    }
}
