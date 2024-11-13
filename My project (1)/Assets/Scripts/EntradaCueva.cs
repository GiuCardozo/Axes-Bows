using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bandera : MonoBehaviour
{
    private bool banderaActivada = false;

    public GameManager gameManager;
    public TextMeshProUGUI avisoText;
    private IdiomaManager idiomaManager; // Referencia al IdiomaManager

    void Start()
    {
        // Asegúrate de que el aviso esté vacío al comenzar
        avisoText.text = "";

        // Buscar el IdiomaManager en la escena
        idiomaManager = FindObjectOfType<IdiomaManager>();
    }

    void Update()
    {
        if (!banderaActivada && TodosLosEnemigosDerrotados())
        {
            ActivarBandera();
        }
    }

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

    private void ActivarBandera()
    {
        banderaActivada = true;
        avisoText.text = "¡Ya puedes entrar a la cueva!";
        Invoke("OcultarAviso", 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (banderaActivada)
            {
                gameManager.GuardarPuntos();
                SceneManager.LoadScene("CuevaModoCoop");
            }
            else
            {
                // Mostrar mensaje traducido cuando los enemigos no han sido derrotados
                avisoText.text = idiomaManager.ObtenerTraduccion("avisoEntrada") ?? "¡Derrota a todos los enemigos!";
                Invoke("OcultarAviso", 2f);
            }
        }
    }

    private void OcultarAviso()
    {
        avisoText.text = "";
    }
}
