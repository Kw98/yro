using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class PickUp : Interactable {
        public Item item;

        private void Awake() {
            base.Awake();
            item = Object.Instantiate(item);
        }

        public override void OnInteract()
        {
            if (Inventory.instance.AddItem(this.item)) {
                Destroy(this.gameObject);
            }
        }
    }
}