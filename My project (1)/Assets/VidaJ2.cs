using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJ2 : MonoBehaviour
{

    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    public int valorPrueba;
    
    void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) //Se activa al presionar click 
        {
            TomarDaño(valorPrueba); //metodo para hacer daño
        }

        if(Input.GetButtonDown("Fire2"))
        {
            CurarVida(valorPrueba); //metodo para curar vida
        }
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
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);

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

        cambioVida.Invoke(vidaActual);
    }
}
