using System.Collections;
using System.Collections.Generic;
using SceneManagement;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(Image))]
    public class Picture : RectTransformable
    {
        private static readonly Dictionary<string, Sprite> downloadedImages = new Dictionary<string, Sprite>();
        public static Sprite CurrentlyViewedPicture { get; private set; }

        [SerializeField] private int _viewScene;
        [SerializeField] private float _visiblityCheckPereodicity;
        
        private DownloadState _downloadState = DownloadState.Idle;
        private string _uri;
        private SceneLoader _sceneLoader;

        private Image _image;
        private Image Image => _image ??= GetComponent<Image>();

        public void View()
        {
            if (_downloadState != DownloadState.Completed)
                return;
            
            CurrentlyViewedPicture = _image.sprite;
            _sceneLoader.Load(_viewScene);
        }

        public void Init(SceneLoader sceneLoader, string uri)
        {
            _sceneLoader = sceneLoader;
            _uri = uri;
            StartCoroutine(DownloadStartCheck());
        }

        private IEnumerator DownloadStartCheck()
        {
            while (_downloadState != DownloadState.Completed)
            {
                yield return new WaitForSeconds(_visiblityCheckPereodicity);
                if (_downloadState == DownloadState.Idle && RectTransform.IsCenterVisible())
                    StartCoroutine(DownloadImage());
            }
        }
        
        private IEnumerator DownloadImage()
        {
            if (downloadedImages.ContainsKey(_uri))
            {
                Image.sprite = downloadedImages[_uri];
                _downloadState = DownloadState.Completed;
                yield break;
            }
            
            _downloadState = DownloadState.IsProgress;
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(_uri);
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _downloadState = DownloadState.Idle;
                yield break;
            }
            
            Texture2D texture = ((DownloadHandlerTexture) webRequest.downloadHandler).texture;
            Vector2 textureDimensions = new Vector2(texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, textureDimensions), textureDimensions / 2);

            Image.sprite = sprite;
            downloadedImages.Add(_uri, sprite);
            
            _downloadState = DownloadState.Completed;
        }

        private enum DownloadState
        {
            Idle,
            IsProgress,
            Completed
        }
    }
}