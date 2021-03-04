using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    [DefaultExecutionOrder(-1)]
    public class Timer : MonoBehaviour {
        public float time;
        public bool isFinished { private set { } get { return time >= 0; } }

        void Update() {
            if (time > 0)
                time -= Time.deltaTime;
        }
    }
}