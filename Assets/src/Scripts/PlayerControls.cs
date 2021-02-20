using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class PlayerControls : YrBehavior {
        public float speed;
        private Rigidbody _rigidbody;
        private void Start()
        {
            this._rigidbody = this.player.GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            if (Input.GetKeyDown(KeyCode.Z)) {
                this._rigidbody.MovePosition(this.player.transform.position + (Vector3.forward * this.speed * Time.fixedDeltaTime));
            } else if (Input.GetKeyDown(KeyCode.S))
            {
                this._rigidbody.MovePosition(this.player.transform.position + (Vector3.back * this.speed * Time.fixedDeltaTime));
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                this._rigidbody.MovePosition(this.player.transform.position + (Vector3.left * this.speed * Time.fixedDeltaTime));
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                this._rigidbody.MovePosition(this.player.transform.position + (Vector3.right * this.speed * Time.fixedDeltaTime));
            }
        }
    }
}