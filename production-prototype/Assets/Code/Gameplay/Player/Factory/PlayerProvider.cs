namespace Game.Assets.Code.Gameplay.Player.Factory
{
    internal sealed class PlayerProvider
    {
        public PlayerEntity Player { get; private set; }

        internal void SetupPlayer(PlayerEntity player)
        {
            Player = player;
        }
    }
}
