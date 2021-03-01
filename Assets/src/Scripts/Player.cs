using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    [RequireComponent(typeof(RTSControls))]
    public class Player : YBehaviour {
        private RTSControls _controls;

        private void Awake() {
            this._controls = GetComponent<RTSControls>();
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(1)) {
                this._controls.Move();
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                this._controls.Stop();
            }  

        }

        private void OnFocus()
        {
            //if (this._lastHit && this._lastHit.tag == "Enemy")
            //{
            //    //Physics.Raycast(this.transform.position, this._lastHit.position - this.transform.position, out RaycastHit hit) && hit.distance <= this._attackRange && hit.transform == this._lastHit
            //    if (Vector3.Distance(this.transform.position, this._lastHit.position) <= this._attackRange)
            //    {
            //        this._agent.isStopped = true;
            //        this.LookAt(this._lastHit.position - this.transform.position);
            //    }
            //}
        }
    }
}