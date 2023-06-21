using UnityEngine;
using UnityEngine.UI;

namespace SceneManagement
{
    public class ProgressBar : RectTransformable
    {
        [SerializeField] private RectMask2D _mask;

        public void UpdateProgress(float progress)
        {
            progress = Mathf.Clamp(progress, 0, 1);
            float barWidth = RectTransform.rect.width * progress;
            Vector4 padding = new Vector4(0, 0, - barWidth, 0);
            _mask.padding = padding;
        }
    }
}