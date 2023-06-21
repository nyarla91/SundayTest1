using UnityEngine;

namespace SceneManagement
{
    public class SceneLoadPresenter : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private ProgressBar _progressBar;

        private void Awake()
        {
            _sceneLoader.StartedLoadingScene += Show;
            _sceneLoader.LoadingScene += _progressBar.UpdateProgress;
        }

        private void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}