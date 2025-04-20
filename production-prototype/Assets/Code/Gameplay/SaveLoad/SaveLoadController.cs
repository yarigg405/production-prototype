using UnityEngine;
using VContainer;


namespace Game.Assets.Code.Gameplay.SaveLoad
{
    internal sealed class SaveLoadController : MonoBehaviour
    {
        private SaveLoadMetaService _saveLoadMetaService;
        private SaveLoadGameService _saveLoadGameService;

        [Inject]
        private void Construct(SaveLoadMetaService saveLoadMetaService, SaveLoadGameService saveLoadGameService)
        {
            _saveLoadMetaService = saveLoadMetaService;
            _saveLoadGameService = saveLoadGameService;
        }

        private void Start()
        {
            _saveLoadGameService.Load();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                Save();
        }

        private void Save()
        {
            _saveLoadMetaService.Save();
            _saveLoadGameService.Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
