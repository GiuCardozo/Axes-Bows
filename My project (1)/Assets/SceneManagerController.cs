using System.Collections;  // Asegúrate de incluir esta línea
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    public GameObject boss; // Referencia al jefe
    public GameObject baculo; // Referencia al Baculo

    private bool bossDestroyed = false;
    private bool baculoDestroyed = false;
    public GameManager gameManager;

    private void Update()
    {
        // Verificar si ambos objetos han sido destruidos
        if (boss == null && !bossDestroyed)
        {
            bossDestroyed = true;
            Debug.Log("El jefe ha sido destruido.");
        }

        if (baculo == null && !baculoDestroyed)
        {
            baculoDestroyed = true;
            Debug.Log("El Baculo ha sido destruido.");
        }

        // Si ambos han sido destruidos, cargar la siguiente escena después de 5 segundos
        if (bossDestroyed && baculoDestroyed)
        {
            StartCoroutine(CargarSiguienteEscenaConRetraso());
        }
    }

    private IEnumerator CargarSiguienteEscenaConRetraso()
    {
        // Esperar 5 segundos antes de cargar la siguiente escena
        yield return new WaitForSeconds(2f);
        gameManager.GuardarPuntos();
        SceneManager.LoadScene("Win");
    }
}


