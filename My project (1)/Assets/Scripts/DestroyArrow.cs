using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("LateDestroy", 10); //Invocar a la funcion de destruir la flecha despu�s de 10 segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("LateDestroy", 3); //Cuando la flecha est� clavada en algo, invocar a la funcion de destruir despues de 3 segundos
        transform.parent = collision.transform;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Quitarle la velocidad a la flecha as� se detiene
        GetComponent<BoxCollider2D>().enabled = false; //Quitar collider para evitar que le haga da�o multiples veces a los enemigos.
    }

    private void LateDestroy() //destruir la flecha
    {
        Destroy(gameObject);
    }
}
