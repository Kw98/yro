using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {

    public enum EquipmentSlot {
        Head,
        Torso,
        Pants,
        Boots,
        Weapon,
        OffHand
    }

    [CreateAssetMenu(fileName = "equipement", menuName = "Yro/equipement", order = 2)]
    public class Equipment : Item {

        public EquipmentSlot slot = EquipmentSlot.Head;
        public bool isTwoHanded = false; // only for weapon
        public Spell[] primary;
        public Spell[] secondary;
        public Spell[] special;
        public Passif[] passif;

        public int currentPrimary = -1;
        public int currentSecondary = -1;
        public int currentSpecial = -1;
        public int currentPassif = -1;

        public override void Use() { }
    }
}