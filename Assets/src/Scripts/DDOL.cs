using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yro {
    public class DDOL : MonoBehaviour {
        [SerializeField] private Game.State _toLoad;
        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
            this.GetComponentInChildren<Game>().state = this._toLoad;
        }
    }
}