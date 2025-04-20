using Game.Assets.Code.Gameplay.Player;
using Game.Assets.Code.Gameplay.Production.Buildings;

namespace Game.Assets.Code.Gameplay.Gathering
{
    internal interface IGatheringSystem
    {
        void PlayerEnterGatheringZone(PlayerEntity player, ProductionBuilding building);
        void PlayerExitGatheringZone(PlayerEntity player, ProductionBuilding building);
    }
}