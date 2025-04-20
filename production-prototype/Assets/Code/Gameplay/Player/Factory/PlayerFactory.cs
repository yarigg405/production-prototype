using Game.Assets.Code.StaticData;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.Player.Factory
{
    internal class PlayerFactory
    {
        private readonly StaticDataContainer _staticData;

        public PlayerFactory(StaticDataContainer staticData)
        {
            _staticData = staticData;
        }

        public PlayerEntity CreatePlayer(Vector3 spawnPos)
        {
            var player = GameObject.Instantiate(_staticData.PlayerPrefab);
            player.transform.position = spawnPos;
            return player;
        }
    }
}
