using UnityEngine;


namespace Yrr.UI.Elements
{
    internal sealed class CustomButtonContentPositionYChanger : MonoBehaviour
    {
        [SerializeField] private CustomButton customButton;
        [SerializeField] private Transform movingRoot;

        [Space]
        private float _defaultYPos;
        [SerializeField] private float pressedPositionY = -10f;
        [SerializeField] private float disabledPositionY = 0;

        private void Awake()
        {
            SetNormal();
            customButton.OnButtonStateChanged += ChangePosition;
        }

        private void OnDestroy()
        {
            customButton.OnButtonStateChanged -= ChangePosition;
        }


        private void ChangePosition(CustomButtonStates state)
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
            var pos = movingRoot.localPosition;
            pos.y = _defaultYPos;
            movingRoot.localPosition = pos;
        }

        private void SetPressed()
        {
            var pos = movingRoot.localPosition;
            pos.y = pressedPositionY;
            movingRoot.localPosition = pos;
        }

        private void SetDisabled()
        {
            var pos = movingRoot.localPosition;
            pos.y = disabledPositionY;
            movingRoot.localPosition = pos;
        }
    }
}
