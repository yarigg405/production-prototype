using Yrr.Audio;


namespace Game.Assets.Code.Gameplay.SaveLoad
{
    internal sealed class GameSettingsContainer
    {
        public float SoundVolume;
        public float MusicVolume;

        public void UpdateVolumeSettings()
        {
            //AudioManager.Instance.SetSoundsVolume(SoundVolume);
            AudioManager.Instance.SetMusicVolume(MusicVolume);
        }
    }
}
