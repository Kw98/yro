using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Yro {

    public enum SpellRessource {
        None,
        Mana,
        Energy,
        Health
    }

    public enum RessourceCostType {
        Flat,
        Percent
    }

    public abstract class Spell : MonoBehaviour {
        public Sprite icon;
        public Sprite preview;

        public SpellRessource ressource;
        public RessourceCostType costType;
        public float cost;
        public float baseCooldown;
        public float currentCooldown;
        public float range;

        public abstract object TextPreview();
        public abstract void SpellPreview();
    }
}