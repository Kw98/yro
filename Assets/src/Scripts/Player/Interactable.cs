using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class Interactable : MonoBehaviour {
        public enum Type {
            Player,
            Enemy,
            Other
        }

        public Type type;
        public float radius = 3f;
        public Transform interactCenter;

        protected void Awake() {
            if (this.interactCenter == null) {
                this.interactCenter = this.transform;
            }
        }

        public virtual void OnInteract() { }

        private void OnDrawGizmos() {
            Gizmos.color = Color.blue;
            if (this.interactCenter == null) {
                Gizmos.DrawWireSphere(this.transform.position, this.radius);
            } else {
                Gizmos.DrawWireSphere(this.interactCenter.position, this.radius);
            }
        }
    }
}