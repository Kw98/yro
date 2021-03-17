using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class PickUp : Interactable {
        public Item item;
        public int stackNb = 1;

        private void Awake() {
            base.Awake();
            item = Object.Instantiate(item);
            if (this.stackNb > item.maxStack)
                this.stackNb = item.maxStack;
            item.currentStack = stackNb;
        }

        public override void OnInteract()
        {
            int left = Inventory.instance.AddItem(this.item);
            Debug.Log("Picking up: " + item.name + " x" + (item.currentStack - left) + " from " + this.gameObject.name);
            if (left <= 0) {
                Destroy(this.gameObject);
            } else {
                item.currentStack = left;
            }
        }
    }
}