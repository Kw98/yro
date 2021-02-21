using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yro
{
    public class RTSControls : YBehaviour {
        private NavMeshAgent _agent;

        private void Awake() {
            this._agent = this.GetComponentInChildren<NavMeshAgent>();
        }

        void Update() {
            if (Input.GetMouseButton(1)) {
                Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue)) {
                    this._agent.destination = hit.point;
                    this._agent.isStopped = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                this._agent.isStopped = true;
            }
        }
    }
}