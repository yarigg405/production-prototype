using System;
using UnityEngine;


namespace Yrr.UI
{
    public sealed class UIManager : MonoBehaviour
    {
        public event Action<IUIScreen> OnScreenShown;
        public event Action<IUIScreen> OnScreenHided;
        public event Action<IUIScreen> OnModalShown;

        private ScreenStorage _screenStorage;
        private ScreenManager _screenManager;


        private void Start()
        {
            _screenStorage = new ScreenStorage();
            _screenManager = new ScreenManager(_screenStorage);

            _screenManager.OnScreenShown += OpenScreenEvent;
            _screenManager.OnScreenHided += HideScreenEvent;
            _screenManager.OnModalShown += OpenModalEvent;


            var windows = transform.GetComponentsInChildren<UIScreen>(true);

            foreach (var screen in windows)
            {
                _screenStorage.AddScreen(screen.GetType(), screen);
                screen.Hide();
                screen.OnHideAction += HideScreenEvent;
            }

            GoToScreen(windows[0]);
        }

        private void OpenModalEvent(IUIScreen screen)
        {
            OnModalShown?.Invoke(screen);
        }

        private void HideScreenEvent(IUIScreen screen)
        {
            OnScreenHided?.Invoke(screen);
        }

        private void OpenScreenEvent(IUIScreen screen)
        {
            OnScreenShown?.Invoke(screen);
        }

        public T GetScreen<T>() where T : IUIScreen
        {
            return (T) _screenStorage.GetScreen(typeof(T));
        }


        #region Open screens methods

        public void GoToScreen(UIScreen screen)
        {
            _screenManager.ChangeScreen(screen.GetType(), null, null);
        }


        public bool GoToScreen(Type key, object args = null)
        {
            _screenManager.ChangeScreen(key, args, null);
            return true;
        }

        public bool GoToScreen(Type key, object args, Action callback)
        {
            _screenManager.ChangeScreen(key, args, callback);
            return true;
        }

        public bool GoToScreen(Type key, Action callback)
        {
            _screenManager.ChangeScreen(key, null, callback);
            return true;
        }


        public bool GoToScreen<T>(object args = null)
        {
            return GoToScreen(typeof(T), args);
        }

        public bool GoToScreen<T>(Action callback)
        {
            return GoToScreen(typeof(T), callback);
        }

        public bool GoToScreen<T>(object args, Action callback)
        {
            return GoToScreen(typeof(T), args, callback);
        }

        #endregion


        #region Open modal methods

        public void OpenModal(UIScreen screen)
        {
            _screenManager.ShowModal(screen.GetType(), null, null);
        }



        public bool OpenModal(Type key, object args = null)
        {
            _screenManager.ShowModal(key, args, null);
            return true;
        }

        public bool OpenModal(Type key, Action callback)
        {
            _screenManager.ShowModal(key, null, callback);
            return true;
        }

        public bool OpenModal(Type key, object args, Action callback)
        {
            _screenManager.ShowModal(key, args, callback);
            return true;
        }



        public bool OpenModal<T>(object args = null)
        {
            return OpenModal(typeof(T), args);
        }

        public bool OpenModal<T>(Action callback)
        {
            return OpenModal(typeof(T), callback);
        }

        public bool OpenModal<T>(object args, Action callback)
        {
            return OpenModal(typeof(T), args, callback);
        }

        #endregion       
    }
}
