using UnityEngine;
using Yrr.Utils;


namespace Yrr.Audio
{
    [CreateAssetMenu(fileName = "SoundCatalog", menuName = "Audio/SoundCatalog")]
    public sealed class SoundCatalog : ScriptableObject
    {
        [SerializeField] private UnityDictionary<string, SoundClip[]> sounds;

        internal SoundClip[] Get(string soundId)
        {
            return sounds.Get(soundId);
        }
    }
}
