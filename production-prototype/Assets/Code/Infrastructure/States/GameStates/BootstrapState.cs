using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Game.Assets.Code.Gameplay.SaveLoad;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class BootstrapState : GameState
    {
        private readonly IStateMachine _stateMachine;
        private readonly SaveLoadMetaService _saveLoadService;

        public BootstrapState(IStateMachine stateMachine, SaveLoadMetaService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public override void Enter()
        {
            _saveLoadService.Load();
            _stateMachine.Enter<LoadGameState, string>(SceneNames.GameScene);
        }
    }
}
