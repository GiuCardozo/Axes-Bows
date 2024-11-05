using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSManager : MonoBehaviour
{
    public int PuntosToT { get { return puntosToT; } }
    private int puntosToT;


    public void SumPuntos(int puntosASum)
    {
        puntosToT += puntosASum;
        Debug.Log(puntosToT);
    }
}
