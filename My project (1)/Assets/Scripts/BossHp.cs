using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public int HP = 5;
    public int valor = 5;
    public GameManager gameManager;
    public float flashDuration = 0.1f;
    public Color damageColor = Color.red; // Color del flash cuando recibe da�o
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject itemDropPrefab; // Prefab del �tem a soltar
    [SerializeField] private float dropChance = 0.5f; // Probabilidad de soltar el �tem (50%)

    private CameraShake cameraShake; // Referencia al script de sacudida de c�mara
    [SerializeField] private Image screenFlash; // Referencia a la imagen de flash en el Canvas
    private Animator animator; // Referencia al Animator

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Guarda el color original del enemigo

        // Obtener referencia al script CameraShake en la c�mara principal
        cameraShake = Camera.main.GetComponent<CameraShake>();

        // Obtener el Animator adjunto al jefe
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") //para sumar puntos al barbaro
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarBarbaro(valor); // Llama a la funci�n de sumar puntos a barbaro
            if (HP <= 0)
            {
                StartCoroutine(Defeat()); // Llama a Defeat como Coroutine
            }
        }

        if (collision.tag == "Projectile") //para sumar puntos al arquero
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarArquero(valor); // Llama a la funci�n de sumar puntos a arquero
            if (HP <= 0)
            {
                StartCoroutine(Defeat()); // Llama a Defeat como Coroutine
            }
        }
    }

    private IEnumerator Defeat()
    {
        gameManager.SumarPuntos(valor);
        TryDropItem();

        // Activar la sacudida de pantalla y el efecto de flash
        StartCoroutine(cameraShake.Shake(0.5f, 0.3f)); // Llama a la sacudida de pantalla
        yield return StartCoroutine(FlashScreen()); // Espera a que el flash termine antes de continuar

        // Activar la animaci�n de muerte
        animator.SetTrigger("Death");

        // No destruyas el objeto aqu�; espera al evento de animaci�n OnDeathAnimationEnd
    }


    private IEnumerator FlashDamageEffect()
    {
        // Cambia el color del enemigo al color de da�o
        spriteRenderer.color = damageColor;
        // Espera un poco para mantener el efecto
        yield return new WaitForSeconds(flashDuration);
        // Vuelve al color original
        spriteRenderer.color = originalColor;
    }

    private IEnumerator FlashScreen()
    {
        // Cambiar el color de la imagen de flash a rojo opaco
        screenFlash.color = new Color(1, 0, 0, 1); // Rojo opaco
        yield return new WaitForSeconds(0.1f); // Duraci�n del flash
        screenFlash.color = new Color(1, 0, 0, 0); // Rojo transparente
    }

    private void TryDropItem()
    {
        float randomValue = Random.Range(0f, 1f); // Generar un n�mero aleatorio entre 0 y 1

        if (randomValue <= dropChance)
        {
            // Instanciar el �tem en la posici�n del enemigo
            Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
            Debug.Log("�tem soltado.");
        }
        else
        {
            Debug.Log("No se solt� ning�n �tem.");
        }
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject); // Destruye el jefe despu�s de la animaci�n
    }

}



