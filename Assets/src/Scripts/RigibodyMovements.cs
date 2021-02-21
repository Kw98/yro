using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyMovements : YBehaviour {
        public float speed;
        public float jumpForce;
        public float rotationSpeed;

        private Rigidbody _rigidbody;
        private Vector3 _dir;
        private bool isGrounded;
        private bool jump;
        private Vector3 previousMouse;



        private void Start()
        {
            this._rigidbody = this.GetComponent<Rigidbody>();
            this.isGrounded = true;
            this.jump = false;
            this.previousMouse = Input.mousePosition;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && this.isGrounded && !this.jump) {
                this.jump = true;
            }
        }

        private void OnCollisionEnter(Collision collision) {
            foreach (ContactPoint contactPoint in collision.contacts) {
                if (contactPoint.normal.y > 0) {
                    this.isGrounded = true;
                    break;
                }
            }
        }

        private void FixedUpdate()
        {

            this._dir = Vector3.zero;
            if (Input.GetKey(KeyCode.Z))
            {
                this._dir += this.transform.forward;
            } else if (Input.GetKey(KeyCode.S)) {
                this._dir -= this.transform.forward;
            } 
            if (Input.GetKey(KeyCode.Q)) {
                this._dir -= this.transform.right;
            } else if (Input.GetKey(KeyCode.D)) {
                this._dir += this.transform.right;
            }
            if (this.jump && this.isGrounded) {
                this.isGrounded = false;
                this._rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            //Vector3 currentMouse = Input.mousePosition;
            //Debug.Log("prev: " + this.previousMouse + " current: " + currentMouse + " dif: " + (currentMouse - this.previousMouse));
            //float mouseX = (currentMouse - this.previousMouse).x;
            //this.previousMouse = currentMouse;
            this._rigidbody.MoveRotation(Quaternion.Euler((Vector3.up  * ((Input.mousePosition.x / Screen.height) * 2 - 1) * rotationSpeed * Time.fixedDeltaTime)));
            //this.cam.transform.RotateAround(this.transform.position, )
            this.jump = false;
            this._rigidbody.MovePosition(this.transform.position + (this._dir * this.speed * Time.fixedDeltaTime));
        }
    }
}