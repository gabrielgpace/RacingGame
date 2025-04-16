using UnityEngine;

public class CrosshairFollow : MonoBehaviour
{
    public RectTransform crosshair;

    void Update()
    {
        crosshair.position = Input.mousePosition;
    }
}
