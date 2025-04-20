using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Gameplay.Level
{
    internal sealed class PlayerSpawnPosition : MonoBehaviour
    {
        [field: SerializeField] public Transform SpawnPosition;

        [Inject]
        private void Construct(LevelDataProvider levelDataProvider)
        {
            levelDataProvider.SetupSpawnPosition(this);
        }
    }
}
