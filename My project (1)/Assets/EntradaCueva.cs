using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    private bool banderaActivada = false;

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
        // Busca todos los objetos con el tag "Enemigo" y verifica si hay alguno activo
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
        // Aqu� podr�as agregar efectos visuales o de sonido para indicar que la bandera est� activada
        Debug.Log("�La entrada est� activada! Puedes avanzar");
    }

    // Detectar colisi�n con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (banderaActivada && other.CompareTag("Player"))
        {
            // Cambiar a la siguiente escena (aseg�rate de agregar la escena en el Build Settings de Unity)
            SceneManager.LoadScene("CuevaModoCoop");
        }
    }
}

