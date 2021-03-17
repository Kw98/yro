using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yro {

    public enum Rarity {
        Normal,
        Rare,
        Elite,
        Super,
        Ultra
    }

    [CreateAssetMenu(fileName = "item", menuName = "Yro/item", order = 1)]
    public class Item : ScriptableObject {
        new public string name = "item";
        public Sprite icon = null;
        public Rarity rarity = Rarity.Normal;
        public int goldValue = 1;
        public int maxStack = 30;
        public int currentStack = 1;
        public virtual void Use() { }

    }
}