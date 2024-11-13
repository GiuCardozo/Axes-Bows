using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IdiomaManager : MonoBehaviour
{
    public TextMeshProUGUI botonJugarTexto;
    public TextMeshProUGUI seleccionModoTexto;
    public TextMeshProUGUI cooperativoTexto;
    public TextMeshProUGUI versusTexto;

    // Nuevos elementos de texto para los menús de pausa y game over
    public TextMeshProUGUI avisoEntradaTexto;
    public TextMeshProUGUI resumeTexto;
    public TextMeshProUGUI restartTextoPausa;
    public TextMeshProUGUI quitTextoPausa;
    public TextMeshProUGUI restartTextoGameOver;
    public TextMeshProUGUI quitTextoGameOver;

    private Dictionary<string, Dictionary<string, string>> traducciones;
    private string idiomaActual = "es"; // Idioma por defecto

    void Start()
    {
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
            { "jugar", "Jugar" },
            { "seleccionModo", "Selecciona un modo de juego" },
            { "cooperativo", "Cooperativo" },
            { "versus", "Modo Versus" },
            { "avisoEntrada", "¡Derrota a todos los enemigos!" },
            { "resume", "Reanudar" },
            { "restart", "Reiniciar" },
            { "quit", "Salir" }
        };

        // Traducciones al inglés
        traducciones["en"] = new Dictionary<string, string>
        {
            { "jugar", "Play" },
            { "seleccionModo", "Select a game mode" },
            { "cooperativo", "Cooperative" },
            { "versus", "Versus Mode" },
            { "avisoEntrada", "Defeat all enemies!" },
            { "resume", "Resume" },
            { "restart", "Restart" },
            { "quit", "Quit" }
        };

        // Traducciones al portugués
        traducciones["pt"] = new Dictionary<string, string>
        {
            { "jugar", "Jogar" },
            { "seleccionModo", "Selecione um modo de jogo" },
            { "cooperativo", "Cooperativo" },
            { "versus", "Modo Versus" },
            { "avisoEntrada", "Derrote todos os inimigos!" },
            { "resume", "Retomar" },
            { "restart", "Reiniciar" },
            { "quit", "Sair" }
        };
    }

    public void CambiarIdioma(string nuevoIdioma)
    {
        idiomaActual = nuevoIdioma;
        PlayerPrefs.SetString("IdiomaSeleccionado", nuevoIdioma);
        PlayerPrefs.Save();
        ActualizarTraduccion();
    }

    public string ObtenerTraduccion(string clave)
    {
        if (traducciones.ContainsKey(idiomaActual) && traducciones[idiomaActual].ContainsKey(clave))
        {
            return traducciones[idiomaActual][clave];
        }
        return null;
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

            if (avisoEntradaTexto != null && traducciones[idiomaActual].ContainsKey("avisoEntrada"))
                avisoEntradaTexto.text = traducciones[idiomaActual]["avisoEntrada"];

            if (resumeTexto != null && traducciones[idiomaActual].ContainsKey("resume"))
                resumeTexto.text = traducciones[idiomaActual]["resume"];

            if (restartTextoPausa != null && traducciones[idiomaActual].ContainsKey("restart"))
                restartTextoPausa.text = traducciones[idiomaActual]["restart"];

            if (quitTextoPausa != null && traducciones[idiomaActual].ContainsKey("quit"))
                quitTextoPausa.text = traducciones[idiomaActual]["quit"];

            if (restartTextoGameOver != null && traducciones[idiomaActual].ContainsKey("restart"))
                restartTextoGameOver.text = traducciones[idiomaActual]["restart"];

            if (quitTextoGameOver != null && traducciones[idiomaActual].ContainsKey("quit"))
                quitTextoGameOver.text = traducciones[idiomaActual]["quit"];
        }
    }
}

