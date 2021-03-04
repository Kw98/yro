using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Yro
{
    public class RTSControls : YBehaviour {
        [SerializeField, Range(0.0001f, 1.0f)] private float _smoothRotation = 0.2f;
        private NavMeshAgent _agent;
        private Transform _target;

        private void Awake() {
            this._agent = this.GetComponentInChildren<NavMeshAgent>();
            this._agent.updateRotation = false;
        }

        private void LateUpdate() {
            if (!this._agent.isStopped && this._agent.velocity.sqrMagnitude > Mathf.Epsilon) {
                this.LookAt(this._agent.velocity.normalized);
            }

        }

        public void LookAt(Vector3 target) {
            Quaternion rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(target), this._smoothRotation);
            rotation.x = .0f;
            rotation.z = .0f;
            transform.rotation = rotation;
        }

        public void Move(Vector3 position) {
            this._agent.stoppingDistance = 0;
            this._agent.destination = position;
            this._agent.isStopped = false;
        }

        public void SetTarget(Transform target, float stopRange) {
            this._agent.stoppingDistance = stopRange;
            this._target = target;
            StartCoroutine(this.FollowFocus());
        }

        public void UnsetTarget()
        {
            this._target = null;
            this._agent.stoppingDistance = 0;
        }

        IEnumerator FollowFocus() {
            while (this._target) {
                this._agent.destination = this._target.position;
                yield return new WaitForSeconds(1f);
            }
        }

        public void Stop() {
            this._agent.isStopped = true;
        }

    }
}