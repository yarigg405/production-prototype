using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Game.Assets.Code.Gameplay.UI.Elements
{
    internal sealed class ProductionBuildingWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resourceNameTmp;
        [SerializeField] private Image _resourceIcon;

        [Space]
        [SerializeField] private Image _productionPercentFillImage;
        [SerializeField] private TextMeshProUGUI _resourceCountTmp;

        [SerializeField] private UnityEvent _onResourceProducted;


        internal void SetupWidget(Sprite icon, string resourceName)
        {
            _resourceNameTmp.text = resourceName;
            _resourceIcon.sprite = icon;
        }

        internal void UpdateCount(int count)
        {
            _resourceCountTmp.text = count.ToString();
        }

        internal void UpdateProductionPercent(float percent)
        {
            _productionPercentFillImage.fillAmount = percent;
        }

        internal void AnimateResourceProducted()
        {
            _onResourceProducted?.Invoke();
        }
    }
}
