using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP = 5;

    public int valor = 5;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") //para sumar puntos al barbaro
        {
            HP--;
            if(HP <= 0)
            {
                gameManager.SumarPuntos(valor);
                Destroy(gameObject);
            }
        }/*else if (collision.tag == "Projectile")
        {
            HP--;
            if(HP<= 0)
            {
                (hacer el Sumar Puntos de un segundo contador para el jugador 2)
                Destroy(gameObject);
            }
        }*/

    }
}
