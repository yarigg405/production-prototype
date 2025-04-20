using System;


namespace Assets.Code.Infrastructure.Loading
{
    internal interface IScenesLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }
}