using System.Collections;
using UnityEngine;


namespace Yrr.Utils
{
    public sealed class SpeedReckoner : MonoBehaviour
    {
        [SerializeField] private float updateDelay = 0.05f;
#if UNITY_EDITOR
        [ReadOnly]
#endif
        public float Speed;


        private void OnEnable()
        {
            StartCoroutine(ReckonerCoroutine());
        }


        private IEnumerator ReckonerCoroutine()
        {
            var timedWait = new WaitForSeconds(updateDelay);
            var lastPosition = transform.position;
            float lastTimestamp = Time.time;

            while (enabled)
            {
                yield return timedWait;

                var deltaPosition = (transform.position - lastPosition).magnitude;
                var deltaTime = Time.time - lastTimestamp;

                if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
                    deltaPosition = 0f;

                Speed = deltaPosition / deltaTime;

                lastPosition = transform.position;
                lastTimestamp = Time.time;
            }
        }
    }
}
