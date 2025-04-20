using System;
using UnityEngine;
using Yrr.Utils;


namespace Yrr.Audio
{
    public sealed class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private SoundVolumeChanger volumeChanger;

        [Space]
        [SerializeField] private SoundChannel uiChannel;
        [SerializeField] private SoundChannel fxChannel;
        [SerializeField] private SoundChannel musicChannel;
        [SerializeField] private SoundChannel ambienceChannel;


        public void PlayUiSound(string soundId)
        {
            uiChannel.PlaySoundOnCamera(soundId);
        }

        public void PlayUiSound(AudioClip clip)
        {
            uiChannel.PlaySoundOnCamera(clip);
        }


        public void PlaySoundOnObject(string soundId, Transform parent)
        {
            fxChannel.PlaySoundOnObject(soundId, parent);
        }

        public void PlaySoundOnObject(AudioClip clip, Transform parent)
        {
            fxChannel.PlaySoundOnObject(clip, parent);
        }


        public void PlaySoundInPosition(string soundId, Vector3 position)
        {
            fxChannel.PlaySoundInPosition(soundId, position);
        }

        public void PlaySoundInPosition(AudioClip clip, Vector3 position)
        {
            fxChannel.PlaySoundInPosition(clip, position);
        }


        public void PlayAmbience(string soundId, float startPlayTime = 0)
        {
            ambienceChannel.PlaySoundOnCamera(soundId, startPlayTime);
        }

        public void PlayAmbience(AudioClip clip)
        {
            ambienceChannel.PlaySoundOnCamera(clip);
        }

        public void StopAmbience()
        {
            ambienceChannel.StopAll();
        }


        public void PlayMusic(string soundId, float startPlayTime = 0)
        {
            musicChannel.PlaySoundOnCamera(soundId, startPlayTime);
        }

        public void PlayMusic(AudioClip clip)
        {
            musicChannel.PlaySoundOnCamera(clip);
        }


        public void SetSoundsVolume(float volume)
        {
            volumeChanger.SetSoundsVolume(volume);
        }

        public void SetMusicVolume(float volume)
        {
            volumeChanger.SetMusicVolume(volume);
        }

    }
}
