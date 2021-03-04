using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class Equipment : MonoBehaviour {
        public enum Type {
            Head,
            Armor,
            Boots
        }

        public Type type;
        public Spell[] primary;
        public Passif[] passif;

        public int currentPrimary;
        public int currentPassif;
    }
}