using Game.Assets.Code.Gameplay.Player;
using Game.Assets.Code.Gameplay.Production.Buildings;
using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Gameplay.Gathering
{
    internal sealed class GatheringTrigger : MonoBehaviour
    {
        [SerializeField] private ProductionBuilding _building;
        [Inject] private readonly IGatheringSystem _gatheringSystem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerEntity>(out var player))
            {
                _gatheringSystem.PlayerEnterGatheringZone(player, _building);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PlayerEntity>(out var player))
            {
                _gatheringSystem.PlayerExitGatheringZone(player, _building);
            }
        }
    }
}
