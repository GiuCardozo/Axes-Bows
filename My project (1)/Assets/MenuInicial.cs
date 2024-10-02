using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Aseg�rate de importar TextMeshPro

public class MenuInicial : MonoBehaviour
{
    public TextMeshProUGUI botonJugarTexto;  // Cambia de Text a TextMeshProUGUI
    public Idioma idiomaActual;   // Variable para almacenar el idioma actual

    // Diccionario que contiene las traducciones para el bot�n de Jugar
    private Dictionary<Idioma, string> traduccionesJugar = new Dictionary<Idioma, string>()
    {
        { Idioma.Espa�ol, "Jugar" },
        { Idioma.Brasilero, "Jogar" },
        { Idioma.Ingles, "Play" }
    };

    // Este m�todo se llama cuando se presiona el bot�n de Jugar
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Este m�todo actualiza el texto del bot�n dependiendo del idioma seleccionado
    public void CambiarIdioma(Idioma nuevoIdioma)
    {
        idiomaActual = nuevoIdioma;
        botonJugarTexto.text = traduccionesJugar[idiomaActual];  // Cambia el texto del bot�n de Jugar
        if (botonJugarTexto != null)
        {
            botonJugarTexto.text = traduccionesJugar[idiomaActual];  // Cambia el texto del bot�n de Jugar
        }
        else
        {
            Debug.LogError("El componente botonJugarTexto no est� asignado en el Inspector.");
        }
    }

    // M�todos para cambiar el idioma desde los botones
    public void CambiarIdiomaAEspa�ol()
    {
        CambiarIdioma(Idioma.Espa�ol);
    }

    public void CambiarIdiomaABrasilero()
    {
        CambiarIdioma(Idioma.Brasilero);
    }

    public void CambiarIdiomaAIngles()
    {
        CambiarIdioma(Idioma.Ingles);
    }

    // M�todo para iniciar el men� con el idioma predeterminado
    private void Start()
    {
        CambiarIdioma(idiomaActual);  // Aseg�rate de que el bot�n empiece con el idioma correcto
    }
}
