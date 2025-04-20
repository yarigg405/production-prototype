using UnityEngine;
using Yrr.Utils;


namespace Game.Assets.Code.Gameplay.ProductionResources
{
    [CreateAssetMenu(fileName = "ResourcesStaticData", menuName = "ScriptableObjects/ProductionResourcesStaticData", order = 51)]
    internal sealed class ProductionResourcesStaticData : ScriptableObject
    {
        [field: SerializeField] public UnityDictionary<ResourceType, ResourceItemData> ResourcesData;
    }
}
