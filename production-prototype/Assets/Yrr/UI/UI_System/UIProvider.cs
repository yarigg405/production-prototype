using UnityEngine;
using Yrr.UI;


namespace Game.UI
{
    public sealed class UIProvider : MonoBehaviour
    {
        [SerializeField] private UIManager manager;
        public static UIManager UIManager => Instance.manager;

        public static UIProvider Instance
        {
            get
            {
                if (!_instance)
                    _instance = GameObject.FindObjectOfType<UIProvider>();
                return _instance;
            }
        }
        private static UIProvider _instance;


        private void Awake()
        {
            _instance = this;

            Instance.manager.OnModalShown += PlayOpenScreenSound;
            Instance.manager.OnScreenHided += PlayCloseScreenSound;
        }

        private void OnDestroy()
        {
            Instance.manager.OnModalShown -= PlayOpenScreenSound;
            Instance.manager.OnScreenHided -= PlayCloseScreenSound;
        }

        private void PlayOpenScreenSound(IUIScreen screen)
        {
            
        }

        private void PlayCloseScreenSound(IUIScreen screen)
        {
           
        }
    }
}
