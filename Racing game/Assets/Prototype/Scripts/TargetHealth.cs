using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;

    public TextMeshProUGUI damageText;
    public float damageTextDuration = 1.5f;
    private float damageTextTimer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        if (damageText != null) damageText.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
        ShowDamage(damage);

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // ou chame target.DestroyTarget() se quiser
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.size = currentHealth / maxHealth;
        }
    }

    void Update()
    {
        if (damageText != null && damageText.gameObject.activeSelf)
        {
            damageTextTimer -= Time.deltaTime;
            if (damageTextTimer <= 0f)
            {
                damageText.gameObject.SetActive(false);
            }
        }
    }

    [SerializeField] private GameObject damageTextObject;

    void ShowDamage(float amount)
    {
        damageTextObject.SetActive(false); // desativa primeiro
        damageTextObject.SetActive(true);  // ativa novamente e força OnEnable()
    }
}
