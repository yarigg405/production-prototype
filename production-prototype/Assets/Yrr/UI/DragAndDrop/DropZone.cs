using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Yrr.UI.DragAndDrop
{
    public abstract class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private UnityEvent onDropSuccess;
        [SerializeField] private UnityEvent onDropFail;


        public static DropZone CurrentDropZone { get; private set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CurrentDropZone = this;
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            CurrentDropZone = null;
        }


        protected abstract bool CanDropHere(DraggableComponent draggable);

        protected abstract void HandleDroppedItem(DraggableComponent draggable);

        public void DropHere(DraggableComponent draggable)
        {
            if (CanDropHere(draggable))
            {
                HandleDroppedItem(draggable);
                onDropSuccess?.Invoke();
            }

            else
            {
                onDropFail?.Invoke();
            }
        }
    }
}
