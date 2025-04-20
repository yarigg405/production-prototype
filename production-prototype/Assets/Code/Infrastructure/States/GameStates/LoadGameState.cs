using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Game.Assets.Code.Infrastructure.States.GameStates;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class LoadGameState : GamePayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly IScenesLoader _sceneLoader;

        public LoadGameState(IStateMachine stateMachine,
            IScenesLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public override void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, EnterBattleLoopState);
        }

        private void EnterBattleLoopState()
        {
            _stateMachine.Enter<EnterGameState>();
        }
    }
}
