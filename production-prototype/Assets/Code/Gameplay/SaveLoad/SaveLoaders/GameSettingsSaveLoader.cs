using Game.Assets.Code.Gameplay.SaveLoad.Infrastructure;


namespace Game.Assets.Code.Gameplay.SaveLoad.SaveLoaders
{
    internal sealed class GameSettingsSaveLoader : MetaSaveLoader<GameSettingsContainer, GameSettingsContainer>
    {
        protected override GameSettingsContainer ConvertToSaveData(GameSettingsContainer service)
        {
            return service;
        }

        protected override void LoadService(GameSettingsContainer service, GameSettingsContainer data)
        {
            if (data == null)
            {
                service.MusicVolume = 0.5f;
                service.SoundVolume = 0.5f;
                service.UpdateVolumeSettings();
                return;
            }

            service.MusicVolume = data.MusicVolume;
            service.SoundVolume = data.SoundVolume;
            service.UpdateVolumeSettings();
        }
    }
}
