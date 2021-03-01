using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yro {
    public enum SpellSource {
        None,
        Mana,
        Energy,
        Health
    }

    public enum SpellCostType {
        Flat,
        Percent
    }

    public enum SpellCast {
        KeyDown,
        KeyUp,
    }

    public class Spell : MonoBehaviour {
        public uint entityId;
        public Sprite icon;
        public Sprite preview;
        public SpellSource source;
        public SpellCostType costType;
        public float cost;
        public float cooldown;
        public int level;
        public float range;
        public int slot;

        public virtual void Launch() { }
        public virtual void Preview() { }

        // save the spell slot to know wich keycode to check
    }
}