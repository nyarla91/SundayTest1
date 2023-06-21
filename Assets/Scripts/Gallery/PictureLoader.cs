using SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class PictureLoader : RectTransformable
    {
        [SerializeField] private string _uriPrefix;
        [SerializeField] private string _uriSuffix;
        [SerializeField] private int _picturesCount;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private GameObject _picturePrefab;

        private void Start()
        {
            for (int i = 1; i < _picturesCount + 1; i++)
            {
                CreatePicture(i);
            }
        }

        private void CreatePicture(int index)
        {
            Picture picture = Instantiate(_picturePrefab, RectTransform).GetComponent<Picture>();
            picture.Init(_sceneLoader, $"{_uriPrefix}{index}{_uriSuffix}");
        }
    }
}