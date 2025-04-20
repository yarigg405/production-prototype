using UnityEngine;


namespace Game.Assets.Code.Gameplay.Level
{
    internal sealed class LevelDataProvider
    {
        public Vector3 SpawnPosition { get; private set; }

        public void SetupSpawnPosition(PlayerSpawnPosition spawnPosition)
        {
            SpawnPosition = spawnPosition.SpawnPosition.position;
        }
    }
}
