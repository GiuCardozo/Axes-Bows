using UnityEngine;

public class BaculoDestruction : MonoBehaviour
{
    public GameObject boss; // Referencia al GameObject del jefe

    private void Update()
    {
        if (boss == null) // Si el jefe ha sido destruido
        {
            Destroy(gameObject); // Destruir el Baculo
        }
    }
}
