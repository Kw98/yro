using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Yro {
    public struct DFloat {
        float first;
        float second;
    }

    [Serializable]
    public struct StatRessource {
        SpellSource sourceType;
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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}