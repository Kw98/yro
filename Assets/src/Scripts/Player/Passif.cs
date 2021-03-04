using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yro {

    public abstract class Passif : MonoBehaviour {
        public Sprite icon;

        public abstract object TextPreview();
    }
}