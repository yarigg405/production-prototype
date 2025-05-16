using Game.Assets.Code.Gameplay.ProductionResources;
using System;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.Production
{
    [Serializable]
    internal struct ProductionBuildingConfig
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public float ProductionTickTime { get; private set; }
        [field: SerializeField] public int ResourcesCountPerTick { get; private set; }
        [field: SerializeField] public int ResourcesCountLimit { get; private set; }
    }
}
