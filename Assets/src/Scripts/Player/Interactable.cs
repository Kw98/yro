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

        public virtual void OnInteract() { }

        private void OnDrawGizmos() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.interactCenter.position, this.radius);
        }
    }
}