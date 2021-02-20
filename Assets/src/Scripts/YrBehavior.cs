using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yro {
    public class YrBehavior : MonoBehaviour {

        private static Game GAME;
        private static Player PLAYER;
        private static Cam CAM;

        public Game game {
            private set { }
            get {
                if (GAME == null) {
                    GAME = FindObjectOfType<Game>();
                }
                return GAME;
            }
        }

        public Player player {
            private set { }
            get {
                if (PLAYER == null) {
                    PLAYER = FindObjectOfType<Player>();
                }
                return PLAYER;
            }
        }

        public Cam cam {
            private set { }
            get {
                if (CAM == null) {
                    CAM = FindObjectOfType<Cam>();
                }
                return CAM;
            }
        }

    }
}