using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Game.Assets.Code.Gameplay.UI.Elements
{
    internal sealed class ResourceInStorageCell : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameTmp;
        [SerializeField] private TextMeshProUGUI _countTmp;

        [SerializeField] private UnityEvent _onCountUpdatedEvent;

        internal void Setup(Sprite icon, string name, int count)
        {
            _icon.sprite = icon;
            _nameTmp.text = name;
            _countTmp.text = count.ToString();
        }

        internal void SetupCount(int count)
        {
            _countTmp.text = count.ToString();
        }

        internal void UpdateCount(int count)
        {
            _countTmp.text = count.ToString();
            _onCountUpdatedEvent?.Invoke();
        }
    }
}
