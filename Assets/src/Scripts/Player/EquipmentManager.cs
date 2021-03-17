using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class EquipmentManager : MonoBehaviour {
        public Equipment[] equipments;

        public static EquipmentManager instance;

        private void Awake()
        {
            if (EquipmentManager.instance == null)
            {
                EquipmentManager.instance = this;
                DontDestroyOnLoad(this.gameObject);
                this.equipments = new Equipment[System.Enum.GetValues(typeof(EquipmentSlot)).Length];
            } else
            {
                Destroy(this.gameObject);
            }
        }

    }
}