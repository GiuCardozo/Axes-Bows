using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSeleccion : MonoBehaviour
{
    public IdiomaManager idiomaManager; // Referencia al IdiomaManager

    public void Cooperativo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Versus()
    {
        Debug.Log("Iniciar modo VS...");
        SceneManager.LoadScene("ModoVS");
    }

    // Métodos para cambiar el idioma
    public void CambiarIdiomaEspañol()
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
