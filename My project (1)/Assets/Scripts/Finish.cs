using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    private bool banderaActivada = false;

    public GameManager gameManager;
    public TextMeshProUGUI avisoText; // Referencia al TextMeshProUGUI para el aviso

    void Start()
    {
        // Asegúrate de que el aviso esté vacío al comenzar
        avisoText.text = "";
    }

    void Update()
    {
        // Verificar si todos los enemigos han sido derrotados
        if (!banderaActivada && TodosLosEnemigosDerrotados())
        {
            ActivarBandera();
        }
    }

    // Método para verificar si todos los enemigos están derrotados
    private bool TodosLosEnemigosDerrotados()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    // Método para activar la bandera
    private void ActivarBandera()
    {
        banderaActivada = true;
        avisoText.text = "¡Ya puedes avanzar!";
        Invoke("OcultarAviso", 2f);
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (banderaActivada)
            {
                // Si la bandera está activada, cambia a la siguiente escena
                gameManager.GuardarPuntos();
                SceneManager.LoadScene("Win"); // Cambio a la escena "Win"
            }
            else
            {
                // Si la bandera no está activada, muestra el aviso
                avisoText.text = "¡Derrota a todos los enemigos!";
                Invoke("OcultarAviso", 2f); // Oculta el aviso después de 2 segundos
            }
        }
    }

    // Método para ocultar el aviso
    private void OcultarAviso()
    {
        avisoText.text = "";
    }
}

