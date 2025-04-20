using UnityEngine;
using UnityEngine.UI;


namespace Yrr.UI.Elements
{
    internal sealed class CustomButtonSpriteChanger : MonoBehaviour
    {
        [SerializeField] private CustomButton customButton;
        [SerializeField] private Image changedImage;
        [Space]

        private Sprite _normalSprite;
        [SerializeField] private Sprite pressedSprite;
        [SerializeField] private Sprite disabledSprite;

        private void Awake()
        {
            _normalSprite = changedImage.sprite;
            customButton.OnButtonStateChanged += ChangeSprite;
        }

        private void OnDestroy()
        {
            customButton.OnButtonStateChanged -= ChangeSprite;
        }

        private void ChangeSprite(CustomButtonStates state)
        {
            switch (state)
            {
                case CustomButtonStates.Normal:
                    SetNormal(); break;

                case CustomButtonStates.Pressed:
                    SetPressed(); break;

                case CustomButtonStates.Disabled:
                    SetDisabled(); break;
            }
        }

        private void SetNormal()
        {
            changedImage.sprite = _normalSprite;
        }

        private void SetPressed()
        {
            if (pressedSprite)
                changedImage.sprite = pressedSprite;
            else
                changedImage.sprite = _normalSprite;
        }

        private void SetDisabled()
        {
            if (disabledSprite)
                changedImage.sprite = disabledSprite;
            else
                changedImage.sprite = _normalSprite;
        }
    }
}
