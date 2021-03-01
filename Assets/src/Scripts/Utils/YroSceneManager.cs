using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yro {
    [DefaultExecutionOrder(-1)]
    public class YroSceneManager : MonoBehaviour {
        private static YroSceneManager _instance;
        public static YroSceneManager instance {
            private set { }
            get {
                if (YroSceneManager._instance == null)
                    YroSceneManager._instance = FindObjectOfType<YroSceneManager>();
                if (YroSceneManager._instance == null) {
                    GameObject container = new GameObject("sceneManager");
                    YroSceneManager._instance = container.AddComponent<YroSceneManager>();
                }
                return YroSceneManager._instance;
            }
        }

        public const string gameScene = "Game";
        public const string menuScene = "Menu";

        public static void LoadScene(string scene, LoadSceneMode mode = LoadSceneMode.Single) {
            if (!SceneManager.GetSceneByName(scene).isLoaded) {
                YroSceneManager.instance.StartCoroutine(YroSceneManager.instance._LoadScene(scene, mode));
            }
        }

        public static void UnloadScene(string scene, UnloadSceneOptions mode = UnloadSceneOptions.UnloadAllEmbeddedSceneObjects) {
            if (SceneManager.GetSceneByName(scene).isLoaded) {
                YroSceneManager.instance.StartCoroutine(YroSceneManager.instance._UnloadScene(scene, mode));
            }
        }

        private IEnumerator _LoadScene(string scene, LoadSceneMode mode = LoadSceneMode.Single) {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, mode);
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }

        private IEnumerator _UnloadScene(string scene, UnloadSceneOptions mode = UnloadSceneOptions.UnloadAllEmbeddedSceneObjects) {
            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(scene, mode);
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }
    }
}