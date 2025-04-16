using UnityEngine;

public class CarGunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint;         // Objeto no carro que dispara
    public Camera mainCamera;          // A câmera principal
    public float bulletSpeed = 30f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botão esquerdo do mouse
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100); // Ponto distante
        }

        Vector3 direction = (targetPoint - gunPoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
    }
}
