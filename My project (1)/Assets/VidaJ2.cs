using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJ2 : MonoBehaviour
{

    public int vidaActual;
    public int vidaMaxima;
    
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    
    public void TomarDaño(int cantidadDaño)
    {
        int vidaTemporal = vidaActual - cantidadDaño;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;
        }
        else
        {
            vidaActual = vidaTemportal;
        }

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void CurarVida(int cantidadCuracion)
    {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        else
        {
            vidaActual = vidaTemporal;
        }
    }
}
