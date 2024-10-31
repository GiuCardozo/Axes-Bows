using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJ1 : MonoBehaviour
{
    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    public int valorPrueba;
    public float flashDuration = 0.1f;
    public Color damageColor = Color.red;
    public Color healColor = Color.green;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    public float invincibilityDuration = 1.5f;
    private bool isInvincible = false;

    // Referencia al GameManager
    public GameManager gameManager;

    void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (isInvincible) return;

            StartCoroutine(FlashDamageEffect());
            TomarDaño(valorPrueba);
            StartCoroutine(InvincibilityCoroutine());
        }

        if (collision.tag == "Heal")
        {
            StartCoroutine(FlashHealEffect());
            CurarVida(valorPrueba);
        }
    }

    public void TomarDaño(int cantidadDaño)
    {
        int vidaTemporal = vidaActual - cantidadDaño;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);

        if (vidaActual <= 0)
        {
            // Notifica al GameManager que el jugador ha muerto
            if (gameManager != null)
            {
                gameManager.PlayerDied();
                Debug.Log("Player1 muerto");
            }

            Destroy(gameObject);
        }
    }

    public void CurarVida(int cantidadCuracion)
    {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);
    }

    private IEnumerator FlashDamageEffect()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    private IEnumerator FlashHealEffect()
    {
        spriteRenderer.color = healColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}
