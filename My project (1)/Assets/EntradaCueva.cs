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

    // Método para verificar si todos los enemigos están derrotados
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

    // Método para activar la bandera
    private void ActivarBandera()
    {
        banderaActivada = true;
        // Aquí podrías agregar efectos visuales o de sonido para indicar que la bandera está activada
        Debug.Log("¡La entrada está activada! Puedes avanzar");
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (banderaActivada && other.CompareTag("Player"))
        {
            // Cambiar a la siguiente escena (asegúrate de agregar la escena en el Build Settings de Unity)
            SceneManager.LoadScene("CuevaModoCoop");
        }
    }
}

