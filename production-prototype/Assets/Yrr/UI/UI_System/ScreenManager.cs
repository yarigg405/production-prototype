using System;


namespace Yrr.UI
{
    internal sealed class ScreenManager
    {
        internal event Action<IUIScreen> OnScreenShown;
        internal event Action<IUIScreen> OnScreenHided;

        internal event Action<IUIScreen> OnModalShown;

        private readonly ScreenStorage _screenStorage;
        private IUIScreen _currentScreen;

        internal ScreenManager(ScreenStorage screenStorage)
        {
            _screenStorage = screenStorage;
        }


        internal void ChangeScreen(Type key, object args, Action callback)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide();
                OnScreenHided?.Invoke(_currentScreen);
            }

            _currentScreen = _screenStorage.GetScreen(key);
            _currentScreen.Show(args, callback);
            OnScreenShown?.Invoke(_currentScreen);
        }

        internal void ShowModal(Type key, object args, Action callback)
        {
            var modal = _screenStorage.GetScreen(key);
            modal.Show(args, callback);
            OnModalShown?.Invoke(modal);
        }
    }
}
