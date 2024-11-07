using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubHP : MonoBehaviour
{
    public int HP = 5;
    public int valor = 5;
    public GameManager gameManager;
    public float flashDuration = 0.1f;
    public Color damageColor = Color.red; // Color del flash cuando recibe daño
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject itemDropPrefab; // Prefab del ítem a soltar
    [SerializeField] private float dropChance = 0.5f; // Probabilidad de soltar el ítem (50%)

    private void Start()
    {
        // Asigna el SpriteRenderer y guarda el color original del enemigo
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // Busca el GameManager en la escena si no está asignado
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager no encontrado en la escena.");
            }
        }

        // Busca el prefab del ítem en la escena por nombre si no está asignado
        if (itemDropPrefab == null)
        {
            GameObject itemDropObject = GameObject.Find("Curacion"); // Cambia este nombre al del prefab en la escena
            if (itemDropObject != null)
            {
                itemDropPrefab = itemDropObject;
            }
            else
            {
                Debug.LogError("El prefab de itemDropPrefab no está presente en la escena.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") //para sumar puntos al barbaro
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarBarbaro(valor); //Llama a la función de sumar puntos a barbaro
            if (HP <= 0)
            {
                Dead();
            }
        }

        if (collision.tag == "Projectile") //para sumar puntos al arquero
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarArquero(valor); //Llama a la función de sumar puntos a arquero
            if (HP <= 0)
            {
                Dead();
            }
        }
    }

    public void Dead()
    {
        gameManager.SumarPuntos(valor);
        TryDropItem();
        Destroy(gameObject);
    }

    private IEnumerator FlashDamageEffect()
    {
        // Cambia el color del enemigo al color de daño
        spriteRenderer.color = damageColor;
        // Espera un poco para mantener el efecto
        yield return new WaitForSeconds(flashDuration);
        // Vuelve al color original
        spriteRenderer.color = originalColor;
    }

    private void TryDropItem()
    {
        float randomValue = Random.Range(0f, 1f); // Generar un número aleatorio entre 0 y 1

        if (randomValue <= dropChance)
        {
            // Instanciar el ítem en la posición del enemigo
            Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
            Debug.Log("Ítem soltado.");
        }
        else
        {
            Debug.Log("No se soltó ningún ítem.");
        }
    }
}

