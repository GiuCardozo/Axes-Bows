using System.Collections;
using UnityEngine;

public class GhostRubi : MonoBehaviour
{
    [SerializeField] public int valor; // Este valor debe ser negativo si deseas restar puntos
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
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            // Resta puntos al jugador correspondiente
            if (collision.CompareTag("Player"))
            {
                VSManager.SumarBarbaro(-valor); // Aplica el efecto al B�rbaro
            }
            else if (collision.CompareTag("Player2"))
            {
                VSManager.SumarArquero(-valor); // Aplica el efecto al Arquero
            }

            // Inicia la paralizaci�n del jugador sin destruir inmediatamente el �tem
            Debug.Log("Iniciando paralizaci�n del jugador");
            StartCoroutine(ParalizarJugador(collision.gameObject));
        }

        if (collision.CompareTag("Suelo"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    IEnumerator ParalizarJugador(GameObject jugador)
    {
        // Cambia el color del sprite a rosa
        SpriteRenderer spriteRenderer = jugador.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.magenta; // Cambia el color a rosa
        }

        // Det�n la velocidad del jugador y congela sus movimientos
        Rigidbody2D rbJugador = jugador.GetComponent<Rigidbody2D>();
        if (rbJugador != null)
        {
            // Guarda las restricciones actuales
            RigidbodyConstraints2D restriccionesOriginales = rbJugador.constraints;

            // Det�n la velocidad y congela el movimiento
            rbJugador.velocity = Vector2.zero;
            rbJugador.constraints = RigidbodyConstraints2D.FreezeAll;

            Debug.Log("Jugador paralizado por 2 segundos");

            // Espera 2 segundos
            yield return new WaitForSeconds(2);

            Debug.Log("Restaurando movimiento del jugador");

            // Restaura las restricciones originales
            rbJugador.constraints = restriccionesOriginales;

            // Restaura el color original
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.white;
            }

            Debug.Log("Jugador ha sido restaurado completamente");

            // Destruir el �tem despu�s de aplicarse el efecto
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyCoin()
    {
        float destroyTime = 10f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}



