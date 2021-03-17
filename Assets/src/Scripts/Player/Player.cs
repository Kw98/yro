using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
//https://docs.unity3d.com/Manual/class-InputManager.html
namespace Yro {
    [RequireComponent(typeof(RTSControls))]
    public class Player : YBehaviour {

        public Interactable focus;

        private RTSControls _controls;
        private Inventory _inventory;
        private EquipmentManager _equipmentManager;
        private bool _canInteract = true;

        private void Awake() {
            this._controls = GetComponent<RTSControls>();
        }

        void Start()
        {
            this._inventory = Inventory.instance;
            this._equipmentManager = EquipmentManager.instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.GetKey("move")) {
                this.OnMove();
            }
            if (InputManager.GetKey("select")) {
                this.OnSelect();
            }
            this.OnFocus();

        }

        private void OnMove() {
            Ray ray = this.cam.yCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue)) {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                if (interactable != null && interactable.type != Interactable.Type.Player)
                {
                    Debug.Log("Interactable: " + interactable.gameObject.name);
                    this._canInteract = true;
                    this.focus = interactable;
                    float stoppingDistance = interactable.type != Interactable.Type.Enemy ? interactable.radius : 5f;
                    this._controls.SetTarget(this.focus.transform, stoppingDistance);
                    if (this.focus.type == Interactable.Type.Enemy) {
                        this.focus.OnInteract();
                        this._canInteract = false;
                    }
                }
                else
                {
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
                    if (interactable.type != Interactable.Type.Other) {
                        interactable.OnInteract();
                    }
                }
            }
        }

        private void OnFocus()
        {
            if (this.focus)
            {
                float distance = Vector3.Distance(this.transform.position, focus.interactCenter.position);
                float range = focus.type == Interactable.Type.Enemy ? 5f : (focus.radius + .05f);
                if (distance <= range) {
                    this._controls.LookAt((this.focus.transform.position - this.transform.position).normalized);
                    if (this._canInteract == true) {
                        this.focus.OnInteract();
                        this._canInteract = false;
                    }

                    //attack if enemy
                }
            }
        }
    }
}