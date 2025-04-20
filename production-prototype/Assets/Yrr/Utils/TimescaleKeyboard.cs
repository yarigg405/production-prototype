using UnityEngine;


namespace Yrr.Utils
{
    internal sealed class TimescaleKeyboard : MonoBehaviour
    {
        private float _timeScale = 1f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetTimescale(1f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetTimescale(0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetTimescale(5f);
            }

            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                SetTimescale(_timeScale == 0f ? 1f : 0f);
            }
        }

        private void SetTimescale(float timeScale)
        {
            _timeScale = timeScale;
            Time.timeScale = _timeScale;
        }
    }
}
