using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    [SerializeField] public int valor;
    public GameManager VSManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            VSManager.SumarBarbaro(valor);
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Player2"))
        {
            VSManager.SumarArquero(valor);
            Destroy(this.gameObject);
        }
    }
}
