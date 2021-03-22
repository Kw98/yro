using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    [DefaultExecutionOrder(-1)]
    public class ResourcesManager : MonoBehaviour {
        public GameObject ItemUiPrefab;

        public static ResourcesManager instance;
        private void Awake() {
            if (ResourcesManager.instance == null) {
                ResourcesManager.instance = this;
            } else {
                Destroy(gameObject);
            }
        }

    }
}