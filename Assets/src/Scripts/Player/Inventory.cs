using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class Inventory : MonoBehaviour {
        public int maxItems = 20;
        public List<Item> _items;


        public delegate void OnInventoryUpdate();
        public OnInventoryUpdate onInventoryUpdateCallback;

        public static Inventory instance;

        private void Awake() {
            if (Inventory.instance == null) {
                Inventory.instance = this;
                DontDestroyOnLoad(this.gameObject);
                this._items = new List<Item>();
            } else
            {
                Destroy(this.gameObject);
            }
        }

        public int AddItem(Item item) {
            if (this._items.Find(x => x.name == item.name)) {
                int toAdd = 0;
                this._items.Where(x => x.name == item.name)
                    .ToList()
                    .ForEach(x => {
                        toAdd = x.maxStack - x.currentStack;
                        toAdd = item.currentStack < toAdd ? item.currentStack : toAdd;
                        item.currentStack -= toAdd;
                        x.currentStack += toAdd;
                        if (item.currentStack <= 0)
                            return;
                });

                if (item.currentStack <= 0)
                {
                    if (this.onInventoryUpdateCallback != null) {
                        onInventoryUpdateCallback.Invoke();
                    }
                    return 0;
                }
            }
            
            if (this._items.Count < this.maxItems) {
                this._items.Add(item);
                if (this.onInventoryUpdateCallback != null) {
                    onInventoryUpdateCallback.Invoke();
                }
                return 0;
            }
            return item.currentStack;
        }

        public Item RemoveItem(Item item, int toRemove) {
            Item i = item;
            i.currentStack = toRemove;
            if (toRemove < item.currentStack)
                this._items.Where(x => x == item).Select(x => { x.currentStack -= toRemove; return x; }).ToList();
            else
                this._items.Remove(item);
            onInventoryUpdateCallback.Invoke();
            return i;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B)) {
                Item i = new Item();
                i.currentStack = Random.Range(1, i.maxStack);
                int left = AddItem(i);
                Dump();
                Debug.Log("ileft: " + left);
            }
        }

        private void Dump() {
            Debug.Log("-------------------------------------------------------");
            foreach (Item item in this._items)
            {
                Debug.Log("item: " + item.name + " stacks: " + item.currentStack + "/" + item.maxStack);
            }
        }

    }
}