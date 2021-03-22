using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class Inventory : MonoBehaviour {
        public int maxItems = 20;

        [SerializeField] private GameObject _InventoryUI;
        [SerializeField] private Transform _inventorySlotsParent;
        private List<Item> _items;
        private InventorySlot[] _slots;
        private Timer timer;


        public static Inventory instance;

        private void Awake() {
            if (Inventory.instance == null) {
                Inventory.instance = this;
                DontDestroyOnLoad(this.gameObject);
                this.Setup();
            } else
            {
                Destroy(this.gameObject);
            }
        }

        private void Setup()
        {
            this._items = new List<Item>();
            this._slots = this._inventorySlotsParent.GetComponentsInChildren<InventorySlot>();
            this._InventoryUI.SetActive(false);
            timer = new Timer();
        }

        public bool AddItem(Item item) {
            
            if (this._items.Count < this.maxItems) {
                this._items.Add(item);
                InventorySlot invSlot = this._slots.First(i => i.transform.childCount == 0);
                if (invSlot != null) {
                    ItemUi iUi = Instantiate(ResourcesManager.instance.ItemUiPrefab, invSlot.transform).GetComponent<ItemUi>();
                    iUi.Setup(item);
                }
                return true;
            }
            return false;
        }

        public Item RemoveItem(Item item) {
            Item i = item;
            this._items.Remove(item);
            return i;
        }


        private void Update()
        {
            timer.Update();
            if (InputManager.GetKey("inventory") && timer.time <= 0)
            {
                timer.time = .5f;
                this._InventoryUI.SetActive(!this._InventoryUI.activeInHierarchy);
            }
        }

    }
}