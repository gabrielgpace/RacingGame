using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour

{
    public Camera camera;
    void Awake()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
