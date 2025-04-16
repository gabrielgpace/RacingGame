using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public float bulletDamage = 25f;
    internal bool isHit;

    void FixedUpdate()
    {
        if(lifeTime> 0)
        {
            lifeTime -= Time.deltaTime; // diminui o tempo de vida da bala
        }
        else
        {
            Destroy(gameObject); // destrói a bala se o tempo de vida acabar
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        TargetHealth health = collision.gameObject.GetComponent<TargetHealth>();

        if (target != null && health != null)
        {
            health.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

}
