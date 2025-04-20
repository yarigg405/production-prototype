using System;
using UnityEngine;


namespace Yrr.Audio
{
    [Serializable]
    public class SoundClip
    {
        public AudioClip Clip;
        [Range(0, 2)]
        public float ClipVolume = 0.3f;
        [Range(-3, 3)]
        public float BasePitch = 1f;
        [Range(0, 3)]
        public float PitchRandom = 0.3f;
    }
}
