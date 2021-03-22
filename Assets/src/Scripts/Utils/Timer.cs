using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    [DefaultExecutionOrder(-1)]
    public class Timer : MonoBehaviour {
        public float time;
        public bool once = false;

        public delegate void onTimerFinished();
        public onTimerFinished onFinished;

        public void Update() {
            if (this.time > 0) {
                this.time -= Time.deltaTime;
                this.once = false;
            } else if (this.time <= 0 && !this.once) {
                this.once = true;
                if (this.onFinished != null) {
                    this.onFinished.Invoke();
                }
            }
        }
    }
}