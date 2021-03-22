using System.Collections.Generic;
using UnityEngine;

namespace Yro {

    public class InputManager : MonoBehaviour {

        private static Dictionary<string, KeyCode> inputs;
        
        private void Awake() {
            Destroy(this);
        }

        static InputManager()
        {
            InitializeDictionary();
        }

        private static void InitializeDictionary()
        {
            inputs = new Dictionary<string, KeyCode>();
            inputs.Add("select", KeyCode.Mouse0);
            inputs.Add("move", KeyCode.Mouse1);
            inputs.Add("spell1", KeyCode.Q);
            inputs.Add("spell2", KeyCode.W);
            inputs.Add("spell3", KeyCode.E);
            inputs.Add("special", KeyCode.R);
            inputs.Add("ultime", KeyCode.T);
            inputs.Add("inventory", KeyCode.I);
        }

        public static void Add(string name, KeyCode keycode) {            
            if (inputs.ContainsKey(name)) {
                inputs[name] = keycode;
            } else {
                inputs.Add(name, keycode);
            }
        }

        public static void Remove(string name) {
            inputs.Remove(name);
        }

        public static bool GetKeyDown(string name) {
            return Input.GetKeyDown(inputs[name]);
        }

        public static bool GetKeyUp(string name) {
            return Input.GetKeyUp(inputs[name]);
        }

        public static bool GetKey(string name) {
            return Input.GetKey(inputs[name]);
        }
    }
}