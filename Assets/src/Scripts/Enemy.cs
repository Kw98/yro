using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yro {
    public class Enemy : YBehaviour {
        [SerializeField] private NavMeshAgent _agent;
        void Start() {
            this._agent = this.GetComponentInChildren<NavMeshAgent>();
            this._agent.destination = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}