using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class DontDestroyOnLoadScript : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
