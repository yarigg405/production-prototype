using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Yrr.UI.DragAndDrop
{
    /// <summary>
    /// Just add this to draggable Image.
    /// Drop it to DropZone component
    /// </summary>

    public sealed class DraggableComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] private UnityEvent onBeginDragEvent;
        [SerializeField] private UnityEvent onEndDragEvent;
        [SerializeField] private UnityEvent onClickEvent;

        public object DraggedObjectInfo { get; set; }        //cast this to checked type

        private Transform _parentTransform;
        private Transform _cachedTransform;

        private static Canvas _canvas;                                                   // Canvas for item drag operation
        private const string CanvasName = "DragAndDropCanvas"; // Name of canvas
        private const int CanvasSortOrder = 100;


        private void Awake()
        {
            if (_canvas == null)
            {
                var canvasObj = new GameObject(CanvasName);
                _canvas = canvasObj.AddComponent<Canvas>();
                _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                _canvas.sortingOrder = CanvasSortOrder;
            }

            _cachedTransform = transform;
        }


        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            onBeginDragEvent?.Invoke();

            _parentTransform = _cachedTransform.parent;
            _cachedTransform.SetParent(_canvas.transform);
        }


        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            _cachedTransform.position = Input.mousePosition;
        }


        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            var dropZone = DropZone.CurrentDropZone;
            if (dropZone != null)
            {
                dropZone.DropHere(this);
            }

            onEndDragEvent?.Invoke();

            _cachedTransform.SetParent(_parentTransform);
            _cachedTransform.position = _parentTransform.position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onClickEvent?.Invoke();
        }
    }
}
