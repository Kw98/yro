using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class InventorySlotManager : MonoBehaviour {
        private InventorySlot[] _slots;

        private void Awake() {
            this._slots = GetComponentsInChildren<InventorySlot>();
        }
    }
}