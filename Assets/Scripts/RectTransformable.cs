using UnityEngine;

public class RectTransformable : MonoBehaviour
{
    private RectTransform _rectTransform;

    protected RectTransform RectTransform => _rectTransform ??= GetComponent<RectTransform>();
}