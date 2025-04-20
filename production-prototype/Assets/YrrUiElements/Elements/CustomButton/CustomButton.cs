using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Yrr.UI.Elements
{
    public sealed class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] public UnityEvent OnClick;
        [SerializeField] private CustomButtonEvents events;


        public event Action<CustomButtonStates> OnButtonStateChanged;
        private CustomButtonStates _currentState;
        private bool _isPressed;

        private void OnEnable()
        {
            if (_interactable)
            {
                events.OnNormal?.Invoke();
                SetNewState(CustomButtonStates.Normal);
            }
            else
            {
                events.OnDisable?.Invoke();
                SetNewState(CustomButtonStates.Disabled);
            }
        }

        public bool interactable
        {
            get => _interactable;
            set
            {
                _interactable = value;
                if (_interactable)
                {
                    events.OnNormal?.Invoke();
                    SetNewState(CustomButtonStates.Normal);
                }
                else
                {
                    events.OnDisable?.Invoke();
                    SetNewState(CustomButtonStates.Disabled);
                }
            }
        }
        private bool _interactable = true;


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (!_interactable) return;
            _isPressed = true;

            events.OnPress?.Invoke();
            SetNewState(CustomButtonStates.Pressed);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!_interactable) return;
            if (!_isPressed) return;
            _isPressed = false;

            SetNewState(CustomButtonStates.Normal);
            events.OnNormal?.Invoke();

            if (eventData.hovered.Contains(gameObject))
            {
                OnClick?.Invoke();
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!_interactable) return;
            if (!_isPressed) return;
            _isPressed = false;

            SetNewState(CustomButtonStates.Normal);

            events.OnNormal?.Invoke();
        }

        internal void ClickOnButton()
        {
            if (!_interactable) return;



            OnClick?.Invoke();
        }

        private void SetNewState(CustomButtonStates newState)
        {
            if (newState == _currentState) return;

            _currentState = newState;
            OnButtonStateChanged?.Invoke(newState);
        }
    }

    [Serializable]
    public struct CustomButtonEvents
    {
        [field: SerializeField] public UnityEvent OnNormal { get; private set; }
        [field: SerializeField] public UnityEvent OnPress { get; private set; }
        [field: SerializeField] public UnityEvent OnDisable { get; private set; }
    }
}
