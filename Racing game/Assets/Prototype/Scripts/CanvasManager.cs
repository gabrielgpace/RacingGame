using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetCanvasManager : MonoBehaviour
{
    public Text damageText; 
    public string damageMessage = "Damage: {0}";

    Bullet bullet = new Bullet();
    void Update()
    {
        showDamageText();
    }

    void showDamageText()
    {
        
        if(bullet.isHit)
        {
            damageText.gameObject.SetActive(true);
            damageText.text = string.Format(damageMessage, bullet.bulletDamage);
        }
        else
        {
            damageText.gameObject.SetActive(false);
        }
        damageText.gameObject.SetActive(false);
    }
}
