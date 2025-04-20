using System.Collections;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class ShowElementsByOrderAnimator : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToShow;
        [SerializeField] private float startShowingDelay = 0.5f;
        [SerializeField] private float showObjectDelay = 0.3f;


        private void OnEnable()
        {
            foreach (var obj in objectsToShow)
            {
                obj.SetActive(false);
            }

            StartCoroutine(ShowingCoroutine());
        }

        private IEnumerator ShowingCoroutine()
        {
            yield return new WaitForSecondsRealtime(startShowingDelay);

            foreach (var obj in objectsToShow)
            {
                obj.SetActive(true);
                yield return new WaitForSecondsRealtime(showObjectDelay);
            }
        }
    }
}
