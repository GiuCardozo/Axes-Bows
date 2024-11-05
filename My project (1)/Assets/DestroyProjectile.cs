using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    void Start()
    {
        // Destruye el objeto de la flecha después de 10 segundos
        Destroy(gameObject, 10f);
    }

}
