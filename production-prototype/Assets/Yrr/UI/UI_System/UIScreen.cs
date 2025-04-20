using System;
using UnityEngine;
using UnityEngine.Events;


namespace Yrr.UI
{
    public abstract class UIScreen : MonoBehaviour, IUIScreen
    {
        [SerializeField] private ScreenEvents screenEvents;
        private event Action ClosingCallback;
        [HideInInspector] public event Action<UIScreen> OnHideAction;
        [HideInInspector] public event Action<UIScreen> OnShowAction;

        private bool _isClosing;

        public void Show(object args, Action callback)
        {
            _isClosing = false;
            ShowProcedure();
            ClosingCallback = callback;
            OnShow(args);
            screenEvents.OnShow?.Invoke();
            OnShowAction?.Invoke(this);
        }

        protected virtual void ShowProcedure()
        {
            gameObject.SetActive(true);
        }

        protected virtual void OnShow(object args) { }


        public void SetClosingCallback(Action callback)
        {
            ClosingCallback += callback;
        }


        public void Hide()
        {
            if (!gameObject.activeSelf) return;
            if (_isClosing) return;

            OnHide();
            screenEvents.OnHide?.Invoke();
            OnHideAction?.Invoke(this);
            ClosingCallback?.Invoke();
            ClosingCallback = null;
            HidingProcedure();
        }

        protected virtual void HidingProcedure()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnHide() { }
    }

    [Serializable]
    public struct ScreenEvents
    {
        public UnityEvent OnShow;
        public UnityEvent OnHide;
    }
}