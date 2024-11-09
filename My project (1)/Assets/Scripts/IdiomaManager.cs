using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IdiomaManager : MonoBehaviour
{
    public TextMeshProUGUI botonJugarTexto; // Referencia al texto del botón Jugar
    public TextMeshProUGUI seleccionModoTexto; // Referencia al texto que dice "Selecciona un modo de juego"
    public TextMeshProUGUI cooperativoTexto;   // Referencia al texto del botón Cooperativo
    public TextMeshProUGUI versusTexto;        // Referencia al texto del botón Versus

    private Dictionary<string, Dictionary<string, string>> traducciones;
    private string idiomaActual = "es"; // Idioma por defecto

    void Start()
    {
        // Recuperar el idioma guardado o establecer por defecto el español
        idiomaActual = PlayerPrefs.GetString("IdiomaSeleccionado", "es");
        InicializarTraducciones();
        ActualizarTraduccion();
    }

    void InicializarTraducciones()
    {
        traducciones = new Dictionary<string, Dictionary<string, string>>();

        // Traducciones al español
        traducciones["es"] = new Dictionary<string, string>
        {
            { "jugar", "Jugar" }, // Añadir traducción para el botón Jugar
            { "seleccionModo", "Selecciona un modo de juego" },
            { "cooperativo", "Cooperativo" },
            { "versus", "Modo Versus" }
        };

        // Traducciones al inglés
        traducciones["en"] = new Dictionary<string, string>
        {
            { "jugar", "Play" }, // Añadir traducción para el botón Jugar
            { "seleccionModo", "Select a game mode" },
            { "cooperativo", "Cooperative" },
            { "versus", "Versus Mode" }
        };

        // Traducciones al portugués
        traducciones["pt"] = new Dictionary<string, string>
        {
            { "jugar", "Jogar" }, // Añadir traducción para el botón Jugar
            { "seleccionModo", "Selecione um modo de jogo" },
            { "cooperativo", "Cooperativo" },
            { "versus", "Modo Versus" }
        };
    }

    public void CambiarIdioma(string nuevoIdioma)
    {
        idiomaActual = nuevoIdioma;
        PlayerPrefs.SetString("IdiomaSeleccionado", nuevoIdioma); // Guardar el idioma seleccionado
        PlayerPrefs.Save(); // Asegurarse de que se guarde la configuración
        ActualizarTraduccion();
    }

    void ActualizarTraduccion()
    {
        if (traducciones.ContainsKey(idiomaActual))
        {
            if (botonJugarTexto != null && traducciones[idiomaActual].ContainsKey("jugar"))
                botonJugarTexto.text = traducciones[idiomaActual]["jugar"];

            if (seleccionModoTexto != null && traducciones[idiomaActual].ContainsKey("seleccionModo"))
                seleccionModoTexto.text = traducciones[idiomaActual]["seleccionModo"];

            if (cooperativoTexto != null && traducciones[idiomaActual].ContainsKey("cooperativo"))
                cooperativoTexto.text = traducciones[idiomaActual]["cooperativo"];

            if (versusTexto != null && traducciones[idiomaActual].ContainsKey("versus"))
                versusTexto.text = traducciones[idiomaActual]["versus"];
        }
    }
}
