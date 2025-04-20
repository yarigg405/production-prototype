using System;
using UnityEngine;
using UnityEngine.UI;

namespace Yrr.Audio
{
    internal sealed class SoundVolumeTranslator : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private SoundVolumeChanger volumeChanger;

        private void OnEnable()
        {
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
            UpdateVolume(volumeSlider.value);
        }

        private void OnDisable()
        {
            volumeSlider.onValueChanged.RemoveListener(UpdateVolume);
        }

        private void UpdateVolume(float arg0)
        {
            volumeChanger.SetSoundsVolume(arg0);
        }
    }
}