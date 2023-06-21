using System;
using Gallery;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    [RequireComponent(typeof(Image))]
    public class ViewPicture : MonoBehaviour
    {
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            _image.sprite = Picture.CurrentlyViewedPicture;
        }
    }
}