using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } } //Propiedad que al ser le�da por otro script se nos devolver� el valor de la variable privada de puntos.
    private int puntosTotales;

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }
}
