using UnityEngine;
using TMPro;

public class DamageTextEffect : MonoBehaviour
{
    public float duration = 1.5f;
    public float maxScale = 1.5f;
    public float minScale = 0.5f;

    private float timer;
    private TextMeshProUGUI textMesh;
    private Vector3 originalScale;
    private Color originalColor;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale != Vector3.zero ? transform.localScale : Vector3.one;
        originalColor = textMesh.color;
    }


    void OnEnable()
    {
        timer = duration;
        transform.localScale = originalScale * maxScale;
        textMesh.color = originalColor;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            // Escala decrescendo
            float scale = Mathf.Lerp(minScale, maxScale, timer / duration);
            transform.localScale = originalScale * scale;

            // Fade out (transparência)
            Color c = textMesh.color;
            c.a = Mathf.Lerp(0, originalColor.a, timer / duration);
            textMesh.color = c;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
