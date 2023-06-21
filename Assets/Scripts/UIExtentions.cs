using UnityEngine;

public static class UIExtentions
{
    public static bool IsCenterVisible(this RectTransform rectTransform)
    {
        Rect screenRect = new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height));
        Vector3 center = rectTransform.position;
        return screenRect.Contains(center);
    }
}