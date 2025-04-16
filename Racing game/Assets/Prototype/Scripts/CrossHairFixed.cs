using UnityEngine;
using UnityEngine.EventSystems;

public class CrosshairFixed : MonoBehaviour
{
    public Camera mainCamera;
    public RectTransform crosshair;
    private bool isFixed = false;

    void Update()
    {
        if (!isFixed)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Target"))
                {
                    // Fixa a mira na posição do alvo
                    Vector3 screenPoint = mainCamera.WorldToScreenPoint(hit.point);
                    Vector2 localPos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        crosshair.parent as RectTransform,
                        screenPoint,
                        mainCamera,
                        out localPos
                    );
                    crosshair.anchoredPosition = localPos;
                    isFixed = true;
                }
            }
        }
    }
}
