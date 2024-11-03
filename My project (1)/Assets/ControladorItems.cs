using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorItems : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] items;
    [SerializeField] private float tiempoItems;
    private float tiempoSiguienteItem;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update()
    {
        tiempoSiguienteItem += Time.deltaTime;

        if(tiempoSiguienteItem >= tiempoItems)
        {
            tiempoSiguienteItem = 0;
            CrearItem();
        }
    }

    private void CrearItem()
    {
        int numeroItem = Random.Range(0, items.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(items[numeroItem], posicionAleatoria, Quaternion.identity);
    }
}
