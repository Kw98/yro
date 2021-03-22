using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Yro {
    public class DropItem : MonoBehaviour, IDropHandler
    {
        [SerializeField] private RectTransform[] uiPanels;

        public void OnDrop(PointerEventData eventData) {
            foreach (RectTransform rect in uiPanels) {
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition)) {
                    ItemUi iUi = eventData.pointerDrag.GetComponent<ItemUi>();
                    iUi.transform.SetParent(iUi.oldSlot);
                    return;
                }
            }
        }
    }
}