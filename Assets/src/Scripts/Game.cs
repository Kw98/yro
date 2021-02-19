using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yro {
    public class Game : MonoBehaviour {
        public enum State {
            None,
            Home,
            Playing,
            Pause,
            Win,
            Loose
        }

        private State _state;

        public State state {
            get => this._state;
            set {
                this._state = value;
                if (this._state == State.Home) {
                    if (SceneManager.GetSceneByName("Game").isLoaded) {
                        StartCoroutine(this.UnloadScene());
                    }
                } else if (this._state == State.Playing) {
                    if (!SceneManager.GetSceneByName("Game").isLoaded) {
                        StartCoroutine(this.LoadScene());
                    }
                } else if (this._state == State.Pause) {

                } else if (this._state == State.Win) {

                } else if (this._state == State.Loose) {

                }
            }
        }

        private IEnumerator LoadScene() {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }

        private IEnumerator UnloadScene() {
            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync("Game", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }

    }
}