using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Yro {
    public class InventorySlot : MonoBehaviour, IDropHandler {

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null) {
                ItemUi iUi = eventData.pointerDrag.GetComponent<ItemUi>();
                if (this.transform.childCount == 1) {
                    Transform child = this.transform.GetChild(0);
                    child.SetParent(iUi.oldSlot);
                    child.localPosition = Vector3.zero;
                }
                eventData.pointerDrag.transform.SetParent(this.transform);
            }
        }
    }
}