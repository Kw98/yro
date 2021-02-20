using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class PlayerControls : MonoBehaviour {
        public float speed;
        private Rigidbody _rigidbody;
        private void Start()
        {
            this._rigidbody = this.GetComponent<Rigidbody>();
        }


        //private void Update()
        //{
        //    Vector3 dir = Vector3.zero;
        //    if (Input.GetKey("z")) {
        //        dir = Vector3.forward;
        //    } else if (Input.GetKey("s")) {
        //        dir = Vector3.back;
        //    }
        //    if (Input.GetKey("q"))
        //    {
        //        dir += Vector3.left;
        //    } else if (Input.GetKey("d")) {
        //        dir += Vector3.right;
        //    }
        //    this.transform.position += (dir * this.speed * Time.deltaTime);
        //}

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                this._rigidbody.MovePosition(this.transform.position + (Vector3.forward * this.speed * Time.fixedDeltaTime));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this._rigidbody.MovePosition(this.transform.position + (Vector3.back * this.speed * Time.fixedDeltaTime));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                this._rigidbody.MovePosition(this.transform.position + (Vector3.left * this.speed * Time.fixedDeltaTime));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this._rigidbody.MovePosition(this.transform.position + (Vector3.right * this.speed * Time.fixedDeltaTime));
            }
        }
    }
}