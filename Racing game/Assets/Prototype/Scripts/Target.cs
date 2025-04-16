using UnityEngine;

public class Target : MonoBehaviour
{
    public static int TargetAmount = 0;
    public void DestroyTarget()
    {
        Destroy(gameObject);
        TargetAmount++;
    }
}
