using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJ2 : MonoBehaviour
{

    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    public int valorPrueba;
    public float flashDuration = 0.1f;
    public Color damageColor = Color.red; // Color del flash cuando recibe daño
    public Color healColor = Color.green; //Color del flash cuando se cura
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    public float invincibilityDuration = 1.5f; // Duración de la invencibilidad
    private bool isInvincible = false; // Verifica si el jugador es invulnerable
    FollowAI enemy;

    void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Guardamos el color original del jugador
        //enemy = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<FollowAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") //Al colisionar con un enemigo
        {
            if (isInvincible) return;


            StartCoroutine(FlashDamageEffect());
            TomarDaño(valorPrueba); //metodo para hacer daño
            StartCoroutine(InvincibilityCoroutine());
        }

        if (collision.tag == "Heal")
        {

            StartCoroutine(FlashHealEffect());
            CurarVida(valorPrueba); //metodo para curar vida
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
            enemy.OnTargetDeath();
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
        // Cambia el color del jugador al color de daño
        spriteRenderer.color = damageColor;
        // Espera un poco para mantener el efecto
        yield return new WaitForSeconds(flashDuration);
        // Vuelve al color original
        spriteRenderer.color = originalColor;
    }

    private IEnumerator FlashHealEffect()
    {
        // Cambia el color del jugador al color de curación
        spriteRenderer.color = healColor;
        // Espera un poco para mantener el efecto
        yield return new WaitForSeconds(flashDuration);
        // Vuelve al color original
        spriteRenderer.color = originalColor;
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        // Cambia el color del jugador para indicar que es invulnerable (opcional)
        spriteRenderer.color = new Color(1, 1, 1, 0.5f); // Cambia la transparencia del sprite

        // Espera durante el período de invulnerabilidad
        yield return new WaitForSeconds(invincibilityDuration);

        // Vuelve a ser vulnerable
        isInvincible = false;

        // Restaura el color original del jugador
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}
