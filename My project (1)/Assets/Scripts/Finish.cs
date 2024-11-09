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
        // Aseg�rate de que el aviso est� vac�o al comenzar
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

    // M�todo para verificar si todos los enemigos est�n derrotados
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

    // M�todo para activar la bandera
    private void ActivarBandera()
    {
        banderaActivada = true;
        avisoText.text = "�Ya puedes avanzar!";
        Invoke("OcultarAviso", 2f);
    }

    // Detectar colisi�n con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (banderaActivada)
            {
                // Si la bandera est� activada, cambia a la siguiente escena
                gameManager.GuardarPuntos();
                SceneManager.LoadScene("Win"); // Cambio a la escena "Win"
            }
            else
            {
                // Si la bandera no est� activada, muestra el aviso
                avisoText.text = "�Derrota a todos los enemigos!";
                Invoke("OcultarAviso", 2f); // Oculta el aviso despu�s de 2 segundos
            }
        }
    }

    // M�todo para ocultar el aviso
    private void OcultarAviso()
    {
        avisoText.text = "";
    }
}

