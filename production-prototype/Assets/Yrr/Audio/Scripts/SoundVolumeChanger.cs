using System;
using UnityEngine;
using UnityEngine.Audio;


namespace Yrr.Audio
{
    internal sealed class SoundVolumeChanger : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;

        [SerializeField] private VolumeSettings[] musicSettings;
        [SerializeField] private VolumeSettings[] soundsSettings;

        internal void SetMusicVolume(float volume)
        {
            for (int i = 0; i < musicSettings.Length; i++)
            {
                var set = musicSettings[i];
                var soundValue = ConvertToDb(set.globalModificator * volume);
                if (soundValue < -59) soundValue = -59;
                mixer.SetFloat(set.mixerGroupName, soundValue);
            }
        }

        internal void SetSoundsVolume(float volume)
        {
            for (int i = 0; i < soundsSettings.Length; i++)
            {
                var set = soundsSettings[i];
                var soundValue = ConvertToDb(set.globalModificator * volume);
                if (soundValue < -59) soundValue = -59;
                mixer.SetFloat(set.mixerGroupName, soundValue);
            }
        }

        private float ConvertToDb(float volume)
        {
            return Mathf.Log10(volume) * 20;
        }
    }


    [Serializable]
    internal struct VolumeSettings
    {
        [SerializeField] public string mixerGroupName;
        [SerializeField] public float globalModificator;
    }
}
