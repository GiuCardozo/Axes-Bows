using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Asegúrate de importar TextMeshPro

public class MenuInicial : MonoBehaviour
{
    public TextMeshProUGUI botonJugarTexto;  // Cambia de Text a TextMeshProUGUI
    public Idioma idiomaActual;   // Variable para almacenar el idioma actual

    // Diccionario que contiene las traducciones para el botón de Jugar
    private Dictionary<Idioma, string> traduccionesJugar = new Dictionary<Idioma, string>()
    {
        { Idioma.Español, "Jugar" },
        { Idioma.Brasilero, "Jogar" },
        { Idioma.Ingles, "Play" }
    };

    // Este método se llama cuando se presiona el botón de Jugar
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Este método actualiza el texto del botón dependiendo del idioma seleccionado
    public void CambiarIdioma(Idioma nuevoIdioma)
    {
        idiomaActual = nuevoIdioma;
        botonJugarTexto.text = traduccionesJugar[idiomaActual];  // Cambia el texto del botón de Jugar
        if (botonJugarTexto != null)
        {
            botonJugarTexto.text = traduccionesJugar[idiomaActual];  // Cambia el texto del botón de Jugar
        }
        else
        {
            Debug.LogError("El componente botonJugarTexto no está asignado en el Inspector.");
        }
    }

    // Métodos para cambiar el idioma desde los botones
    public void CambiarIdiomaAEspañol()
    {
        CambiarIdioma(Idioma.Español);
    }

    public void CambiarIdiomaABrasilero()
    {
        CambiarIdioma(Idioma.Brasilero);
    }

    public void CambiarIdiomaAIngles()
    {
        CambiarIdioma(Idioma.Ingles);
    }

    // Método para iniciar el menú con el idioma predeterminado
    private void Start()
    {
        CambiarIdioma(idiomaActual);  // Asegúrate de que el botón empiece con el idioma correcto
    }
}
