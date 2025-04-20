using Game.Assets.Code.Gameplay.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Yrr.Audio;
using Yrr.UI;


namespace Game.Assets.Code.Gameplay.UI.Views
{
    internal sealed class SettingsScreen : UIScreen
    {
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        [Inject] private readonly GameSettingsContainer _settingsContainer;


        protected override void OnShow(object args)
        {
            _musicSlider.value = _settingsContainer.MusicVolume;
            _soundSlider.value = _settingsContainer.SoundVolume;

            _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
            _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
        }


        protected override void OnHide()
        {
            _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
            _soundSlider.onValueChanged.RemoveListener(ChangeSoundVolume);
        }

        private void ChangeMusicVolume(float arg0)
        {
            AudioManager.Instance.SetMusicVolume(arg0);
            _settingsContainer.MusicVolume = arg0;
        }

        private void ChangeSoundVolume(float arg0)
        {
            AudioManager.Instance.SetSoundsVolume(arg0);
            _settingsContainer.SoundVolume = arg0;
        }
    }
}
