using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class DisableDebugger : MonoBehaviour
    {
        private void OnDisable()
        {
            Debug.Log("Im disabled: " + gameObject.name);
        }
    }
}