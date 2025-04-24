using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject playerReference;
    public GameObject child;
    public float Speed;
    void Awake()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        child = playerReference.transform.Find("Camera Constraint").gameObject;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * Speed);
        gameObject.transform.LookAt(playerReference.gameObject.transform.position);
    }
}