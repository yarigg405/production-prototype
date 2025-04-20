using UnityEngine;
using Yrr.Audio;


namespace Yrr.Utils
{
    internal sealed class PlayAudioClip : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private PlaySoundType soundType;


        public void Play()
        {
            switch (soundType)
            {
                case PlaySoundType.InPosition:
                    {
                        AudioManager.Instance.PlaySoundInPosition(clip, transform.position);
                    }
                    break;

                case PlaySoundType.Music:
                    {
                        AudioManager.Instance.PlayMusic(clip);
                    }
                    break;

                case PlaySoundType.Ambience:
                    {
                        AudioManager.Instance.PlayAmbience(clip);
                    }
                    break;

                case PlaySoundType.OnObject:
                    {
                        AudioManager.Instance.PlaySoundOnObject(clip, transform);
                    }
                    break;

                default:
                    {
                        AudioManager.Instance.PlayUiSound(clip);
                    }
                    break;
            }
        }
    }
}
