using Game.Assets.Code.Gameplay.Player;
using UnityEngine;


namespace Game.Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "StaticDataContainer", menuName = "ScriptableObjects/StaticDataContainer", order = 51)]
    internal sealed class StaticDataContainer : ScriptableObject
    {
        [field: SerializeField] public PlayerEntity PlayerPrefab { get; private set; }
    }
}
