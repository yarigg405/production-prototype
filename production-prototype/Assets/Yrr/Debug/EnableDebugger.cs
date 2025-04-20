using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class EnableDebugger : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log("Im enabled: " + gameObject.name);
        }
    }
}