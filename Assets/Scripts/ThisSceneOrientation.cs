using UnityEngine;

public class ThisSceneOrientation : MonoBehaviour
{
    [SerializeField] private ScreenOrientation _orientation;

    private void Start()
    {
        Screen.orientation = _orientation;
    }
}