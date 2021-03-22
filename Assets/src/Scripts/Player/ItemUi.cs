using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Yro {
    public class ItemUi : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Item item;
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        public Transform oldSlot;

        private void Awake()
        {
            this._canvas = FindObjectOfType<Canvas>();
            this._rectTransform = GetComponent<RectTransform>();
            this._canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Setup(Item item)
        {
            this.item = item;
            GetComponent<Image>().sprite = item.icon;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("begindrag");
            this.oldSlot = this.transform.parent;
            this.transform.parent = this._canvas.transform;
            this._rectTransform.SetAsLastSibling();
            this._canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this._rectTransform.anchoredPosition += eventData.delta / this._canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("enddrag");
            this._canvasGroup.blocksRaycasts = true;
            if (transform.parent == this._canvas.transform) {
                Inventory.instance.RemoveItem(this.item);
                Destroy(this.gameObject);
                Debug.Log("DESTRUCTION");
            } else {
                transform.localPosition = Vector3.zero;
            }
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