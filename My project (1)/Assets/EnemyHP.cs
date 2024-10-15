using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
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


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; //guarda el color original del enemigo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") //para sumar puntos al barbaro
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarBarbaro(valor); //Llama a la funci�n de sumar puntos a barbaro
            if(HP <= 0)
            {
                Die();
            }
        }

        if (collision.tag == "Projectile") //para sumar puntos al arquero
        {
            HP--;
            StartCoroutine(FlashDamageEffect());
            gameManager.SumarArquero(valor); //Llama a la funci�n de sumar puntos a arquero
            if (HP <= 0)
            {
                Die();
            }
        }

    }

    public void Die()
    {
        gameManager.SumarPuntos(valor);
        TryDropItem();
        Destroy(gameObject); 
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
}
