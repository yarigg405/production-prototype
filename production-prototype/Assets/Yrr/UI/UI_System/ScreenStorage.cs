using System;
using System.Collections.Generic;


namespace Yrr.UI
{
    internal sealed class ScreenStorage
    {
        private readonly Dictionary<Type, IUIScreen> _screens;

        internal ScreenStorage()
        {
            _screens = new Dictionary<Type, IUIScreen>();
        }

        internal void AddScreen(Type key, IUIScreen value)
        {
            _screens.Add(key, value);
        }

        internal IUIScreen GetScreen(Type key)
        {
            var screen = _screens[key];
            return screen;
        }

    }
}
