using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Yrr.UI.Elements
{
    internal sealed class CustomButtonColorChanger : MonoBehaviour
    {
        [SerializeField] private CustomButton customButton;

        [Space]
        [SerializeField] private Image[] imagesForRecolor;
        [SerializeField] private TextMeshProUGUI[] tmpsForRecolor;

        [Space]        
        [SerializeField] private Color pressedColor = Color.white;
        [SerializeField] private Color disabledColor = new Color(0.78f, 0.78f, 0.78f, 0.5f);

        private Color _normalColor;


        private void Awake()
        {
            if (imagesForRecolor.Length > 0 && imagesForRecolor[0])
            {
                _normalColor = imagesForRecolor[0].color;
            }

            else if (tmpsForRecolor.Length > 0 && tmpsForRecolor[0])
            {
                _normalColor = tmpsForRecolor[0].color;
            }

            else
                _normalColor = Color.white;

            SetNormal();
            customButton.OnButtonStateChanged += ChangeColor;
        }

        private void OnDestroy()
        {
            customButton.OnButtonStateChanged -= ChangeColor;
        }

        private void ChangeColor(CustomButtonStates state)
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
            foreach (var image in imagesForRecolor)
            {
                image.color = _normalColor;
            }

            foreach (var tmp in tmpsForRecolor)
            {
                tmp.color = _normalColor;
            }
        }

        private void SetPressed()
        {
            foreach (var image in imagesForRecolor)
            {
                image.color = pressedColor;
            }

            foreach (var tmp in tmpsForRecolor)
            {
                tmp.color = pressedColor;
            }
        }

        private void SetDisabled()
        {
            foreach (var image in imagesForRecolor)
            {
                image.color = disabledColor;
            }

            foreach (var tmp in tmpsForRecolor)
            {
                tmp.color = disabledColor;
            }
        }
    }
}
