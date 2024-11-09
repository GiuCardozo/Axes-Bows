using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public IdiomaManager idiomaManager; // Referencia al IdiomaManager

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cambia a la siguiente escena
    }

    // M�todos para cambiar el idioma
    public void CambiarIdiomaEspa�ol()
    {
        idiomaManager.CambiarIdioma("es");
    }

    public void CambiarIdiomaIngles()
    {
        idiomaManager.CambiarIdioma("en");
    }

    public void CambiarIdiomaPortugues()
    {
        idiomaManager.CambiarIdioma("pt");
    }
}
