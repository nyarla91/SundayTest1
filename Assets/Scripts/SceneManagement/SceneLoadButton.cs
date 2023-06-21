using UnityEngine;

namespace SceneManagement
{
    public class SceneLoadButton : MonoBehaviour
    {
        [SerializeField] [Tooltip("Does Back button on Android trigger this")] private bool _usesBack;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private int _loadedScene;

        public void LoadScene() => _sceneLoader.Load(_loadedScene);

        private void Update()
        {
            if (_usesBack && Input.GetKeyDown(KeyCode.Escape))
                LoadScene();
        }
    }
}