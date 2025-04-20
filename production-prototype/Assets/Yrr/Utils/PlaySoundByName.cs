using System;
using UnityEngine;
using Yrr.Audio;


namespace Yrr.Utils
{
    internal sealed class PlaySoundByName : MonoBehaviour
    {
        [SerializeField] private string soundName = "ui:click";
        [SerializeField] private PlaySoundType soundType;


        public void Play()
        {
            switch (soundType)
            {
                case PlaySoundType.InPosition:
                    {
                        AudioManager.Instance.PlaySoundInPosition(soundName, transform.position);
                    }
                    break;

                case PlaySoundType.Music:
                    {
                        AudioManager.Instance.PlayMusic(soundName);
                    }
                    break;

                case PlaySoundType.Ambience:
                    {
                        AudioManager.Instance.PlayAmbience(soundName);
                    }
                    break;

                case PlaySoundType.OnObject:
                    {
                        AudioManager.Instance.PlaySoundOnObject(soundName, transform);
                    }
                    break;

                default:
                    {
                        AudioManager.Instance.PlayUiSound(soundName);
                    }
                    break;
            }
        }
    }

    [Serializable]
    internal enum PlaySoundType
    {
        UI,
        Music,
        Ambience,
        OnObject,
        InPosition,
    }
}
