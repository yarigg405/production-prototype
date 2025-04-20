using Game.Assets.Code.Gameplay.Production.Buildings;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.Production.Systems
{
    internal sealed class ProductionBuildingContainer : MonoBehaviour
    {
        [SerializeField] private ProductionBuilding[] _buildings;

        public IEnumerable<ProductionBuilding> Buildings => _buildings;

        [ContextMenu("Find Buildings")]
        private void FindBuildings()
        {
            _buildings = transform.GetComponentsInChildren<ProductionBuilding>();
        }
    }
}
