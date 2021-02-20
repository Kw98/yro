using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yro {
    public class Game : YrBehavior {
        public enum State {
            None,
            Home,
            Playing,
            Pause,
            Win,
            Loose
        }

        private State _state = State.None;

        public State state {
            get => this._state;
            set {
                this._state = value;
                if (this._state == State.Home) {
                    YroSceneManager.UnloadScene(YroSceneManager.gameScene);
                    YroSceneManager.LoadScene(YroSceneManager.menuScene);
                } else if (this._state == State.Playing) {
                    YroSceneManager.UnloadScene(YroSceneManager.menuScene);
                    YroSceneManager.LoadScene(YroSceneManager.gameScene);
                } else if (this._state == State.Pause) {

                } else if (this._state == State.Win) {

                } else if (this._state == State.Loose) {

                }
            }
        }
    }
}