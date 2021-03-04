using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Yro {
    [Serializable]
    public struct DFloat {
        float first;
        float second;
    }

    [Serializable]
    public struct StatRessource {
        public SpellRessource sourceType;
        public float amount;
        public float regen;
    }

    public class Character : MonoBehaviour {
        [Serializable]
        public class Stat {
            public StatRessource health;
            public StatRessource abilitySource;
            public float attackDamage;
            public float magicDamage;
            public float armor;
            public float magicResistance;
            public float attackCritRate;
            public float attackCritDamage;
            public float magicCritRate;
            public float magicCritDamage;
            public float attackRange;
            public float attackSpeed;
            public DFloat moveSpeed;
            public DFloat lifeSteal;
            public DFloat spellVamp;
            public DFloat attackPenetration;
            public DFloat magicPenetration;
            public float haste;
            public float tenacity;

            public Stat() {

            }

        }

       //   public Ability[] abilities { private set { } get { return this.abilities; } }
        public Stat baseStats;
        public Stat totalStats;

        private void Awake() {
        //    abilities = GetComponentsInChildren<Ability>();
        }

    }
}