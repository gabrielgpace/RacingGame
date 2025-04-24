using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour

{
    public Camera gameCamera;
    void Awake()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
