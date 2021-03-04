using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class Weapon : MonoBehaviour {
        public enum Type {
            OneHand,
            TwoHand
        }
        public Type type;
        public Spell[] primary;
        public Spell[] secondary;
        public Spell[] special;
        public Passif[] passif;

        public int currentPrimary;
        public int currentSecondary;
        public int currentSpecial;
        public int currentPassif;
    }
}