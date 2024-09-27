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
        if (collision.tag == "Weapon")
        {
            HP--;
            if(HP <= 0)
            {
                gameManager.SumarPuntos(valor);
                Destroy(gameObject);
            }
        }
    }
}
