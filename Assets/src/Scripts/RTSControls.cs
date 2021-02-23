using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yro
{
    public class RTSControls : YBehaviour {
        [SerializeField] private float _attackRange = 5;
        [SerializeField, Range(0.0001f, 1.0f)] private float _smoothRotation = 0.2f;
        private NavMeshAgent _agent;
        private Transform _lastHit;

        private void Awake() {
            this._agent = this.GetComponentInChildren<NavMeshAgent>();
            this._agent.updateRotation = false;
        }

        void Update() {
            if (Input.GetMouseButton(1)) {
                Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue)) {
                    this._agent.destination = hit.point;
                    this._agent.isStopped = false;
                    this._lastHit = hit.transform;
                }
            }
            if (this._lastHit && this._lastHit.tag == "Enemy" && Vector3.Distance(this.transform.position, this._lastHit.position) <= this._attackRange) {
                this._agent.isStopped = true;
                Vector3 dir = this._lastHit.position - this.transform.position;
                this.LookAt(dir);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                this._agent.isStopped = true;
            }
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

    }
}