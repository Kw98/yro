using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Yro {
    public class ItemUi : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            this._canvas = FindObjectOfType<Canvas>();
            this._rectTransform = GetComponent<RectTransform>();
            this._canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            this._rectTransform.SetAsLastSibling();
            this._canvasGroup.blocksRaycasts = false;
            Debug.Log("begindrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            this._rectTransform.anchoredPosition += eventData.delta / this._canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this._canvasGroup.blocksRaycasts = true;
            Debug.Log("enddrag");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("pointerdown");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("pointerup");
        }
    }
}