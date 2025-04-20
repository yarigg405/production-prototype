using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Game.Assets.Code.Gameplay.Level;
using Game.Assets.Code.Gameplay.Player.Factory;
using Yrr.Audio;


namespace Game.Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class EnterGameState : GameState
    {
        private readonly IStateMachine _stateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly LevelDataProvider _levelDataProvider;
        private readonly PlayerProvider _playerProvider;


        public EnterGameState(
            IStateMachine stateMachine,
            PlayerFactory playerFactory,
            PlayerProvider playerProvider,
            LevelDataProvider levelDataProvider)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _playerProvider = playerProvider;
            _levelDataProvider = levelDataProvider;
        }

        public override void Enter()
        {           
            PlacePlayer();
            AudioManager.Instance.PlayMusic("music");
            _stateMachine.Enter<GameLoopState>();
        }

        private void PlacePlayer()
        {
            var player = _playerFactory.CreatePlayer(_levelDataProvider.SpawnPosition);
            _playerProvider.SetupPlayer(player);
        }
    }
}
