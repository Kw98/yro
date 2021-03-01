using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yro
{
    public class RTSControls : YBehaviour {
        [SerializeField, Range(0.0001f, 1.0f)] private float _smoothRotation = 0.2f;
        private NavMeshAgent _agent;
        public Transform lastHit;

        private void Awake() {
            this._agent = this.GetComponentInChildren<NavMeshAgent>();
            this._agent.updateRotation = false;
        }

        private void LateUpdate() {
            if (!this._agent.isStopped && this._agent.velocity.sqrMagnitude > Mathf.Epsilon) {
                this.LookAt(this._agent.velocity.normalized);
            }

        }

        private void LookAt(Vector3 target) {
            Quaternion rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(target), this._smoothRotation);
            rotation.x = .0f;
            rotation.z = .0f;
            transform.rotation = rotation;
        }

        public void Move() {
            Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue)) {
                this._agent.destination = hit.point;
                this._agent.isStopped = false;
                this.lastHit = hit.transform;
            }
        }

        public void Stop() {
            this._agent.isStopped = true;
        }

    }
}