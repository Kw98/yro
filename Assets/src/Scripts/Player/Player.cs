using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
//https://docs.unity3d.com/Manual/class-InputManager.html
namespace Yro {
    [RequireComponent(typeof(RTSControls))]
    public class Player : YBehaviour {
        public enum FocusState
        {
            None,
            Select,
            Move
        }

        public FocusState focusState;
        public Interactable focus;

        private RTSControls _controls;
        private EquipmentSet _equipmentSet;

        private void Awake() {
            this._controls = GetComponent<RTSControls>();
            this._equipmentSet = GetComponentInChildren<EquipmentSet>();
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.GetKey("move")) {
                this.OnMove();
            }
            if (InputManager.GetKey("select"))
            {
                this.OnSelect();
            }
            this.OnFocus();

        }

        private void OnMove() {
            Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue)) {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                if (interactable != null && interactable.type != Interactable.Type.Player) {
                    this.focusState = FocusState.Move;
                    this.focus = interactable;
                    float stoppingDistance = interactable.type != Interactable.Type.Enemy ? interactable.radius : 5f;
                    this._controls.SetTarget(this.focus.transform, stoppingDistance);
                } else {
                    this.focus = null;
                    this._controls.UnsetTarget();
                    this._controls.Move(hit.point);
                }
            }
        }

        private void OnSelect() {
            Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                if (interactable != null) {
                    this.focusState = FocusState.Select;
                    this.focus = interactable;
                }
            }
        }

        private void OnFocus()
        {
            if (this.focus) {
                if (this.focusState == FocusState.Move) {
                    this.OnMoveFocus();
                } else if (this.focusState == FocusState.Select) {

                }
            }
        }

        private void OnMoveFocus() {
            float distance = Vector3.Distance(this.transform.position, focus.interactCenter.position);
            float range = focus.type == Interactable.Type.Enemy ? 5f : focus.radius;
            if (distance <= range) {
                this._controls.LookAt((this.focus.transform.position - this.transform.position).normalized);
                //attack or interact
            }
        }
    }
}