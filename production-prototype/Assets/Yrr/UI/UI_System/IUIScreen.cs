using System;


namespace Yrr.UI
{
    public interface IUIScreen
    {
        void Show(object args, Action callback);

        void Hide();
    }
}
