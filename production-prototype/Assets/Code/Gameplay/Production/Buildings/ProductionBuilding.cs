using Game.Assets.Code.Gameplay.UI.Elements;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.Production.Buildings
{
    internal sealed class ProductionBuilding : MonoBehaviour
    {
        [field: SerializeField] public string UniqId { get; private set; }
        [field: SerializeField] public ProductionBuildingConfig Config { get; private set; }
        [field: SerializeField] public ProductionBuildingWidget BuildingWidget { get; private set; }
    }
}
