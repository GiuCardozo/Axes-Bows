using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public float initialCooldown = 2f; // Tiempo de enfriamiento inicial antes de la primera activaci�n
    public float activeDuration = 2f; // Tiempo que el invocador estar� activo
    public float interval = 5f; // Intervalo de tiempo entre activaciones
    public GameObject invocador;

    private void Start()
    {
        StartCoroutine(InitialCooldownRoutine());
    }

    private IEnumerator InitialCooldownRoutine()
    {
        // Espera el tiempo de enfriamiento inicial
        yield return new WaitForSeconds(initialCooldown);

        // Inicia la coroutine de activaci�n/desactivaci�n del invocador
        StartCoroutine(ActivateSpawnerRoutine());
    }

    private IEnumerator ActivateSpawnerRoutine()
    {
        while (true)
        {
            // Activa el invocador
            invocador.SetActive(true);

            // Espera el tiempo de duraci�n activa
            yield return new WaitForSeconds(activeDuration);

            // Desactiva el invocador
            invocador.SetActive(false);

            // Espera el intervalo de tiempo hasta la pr�xima activaci�n
            yield return new WaitForSeconds(interval);
        }
    }
}


