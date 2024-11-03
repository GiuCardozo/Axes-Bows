using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    [SerializeField] public int valor;
    private GameManager VSManager;

    private void Start()
    {
        StartCoroutine(DestroyCoin());
        VSManager = FindObjectOfType<GameManager>();

        if (VSManager == null)
        {
            Debug.LogError("GameManager no encontrado en la escena");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            VSManager.SumarBarbaro(valor);
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Player2"))
        {
            VSManager.SumarArquero(valor);
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Suelo"))
        {
            if (collision.CompareTag("Suelo"))
            {
                // Congelar la posici�n en Y
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }

    IEnumerator DestroyCoin()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
