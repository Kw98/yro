using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Yro {
    public class InventorySlot : MonoBehaviour, IDropHandler {
        public Item item;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null) {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            }
        }
    }
}