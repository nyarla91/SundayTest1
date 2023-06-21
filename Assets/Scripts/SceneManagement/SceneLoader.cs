using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public event Action StartedLoadingScene;
        public event Action<float> LoadingScene;
        
        public void Load(int scene) => StartCoroutine(Loading(scene));

        private IEnumerator Loading(int scene)
        {
            StartedLoadingScene?.Invoke();
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
            while ( ! asyncOperation.isDone)
            {
                LoadingScene?.Invoke(asyncOperation.progress);
                yield return null;
            }
        }
    }
}