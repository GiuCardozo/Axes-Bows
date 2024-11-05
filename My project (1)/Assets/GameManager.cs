using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public int puntosArquero;
    public int puntosBarbaro;
    public GameObject gameOverMenu;
    private bool isPlayerDead = false;
    private bool isPlayer2Dead = false;

    private void Start()
    {
        gameOverMenu.SetActive(false);

        // Verificar si es la primera ejecución de la sesión
        if (!PlayerPrefs.HasKey("SesionIniciada"))
        {
            // Establecer la bandera de sesión iniciada
            PlayerPrefs.SetInt("SesionIniciada", 1);
            PlayerPrefs.Save();

            // Restablecer los puntos para comenzar desde cero
            ResetearPuntos();
        }
        else
        {
            // Cargar los puntos desde PlayerPrefs en caso de que no sea la primera sesión
            puntosTotales = PlayerPrefs.GetInt("PuntosTotales", 0);
            puntosArquero = PlayerPrefs.GetInt("PuntosArquero", 0);
            puntosBarbaro = PlayerPrefs.GetInt("PuntosBarbaro", 0);
        }
    }

    private void ResetearPuntos()
    {
        // Reiniciar los puntos al inicio de la sesión
        puntosTotales = 0;
        puntosArquero = 0;
        puntosBarbaro = 0;

        // Opcional: guardar el valor inicial en PlayerPrefs
        GuardarPuntos();
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }

    public void SumarArquero(int puntosASumar)
    {
        puntosArquero += puntosASumar;
    }

    public void SumarBarbaro(int puntosASumar)
    {
        puntosBarbaro += puntosASumar;
    }

    public void GuardarPuntos()
    {
        // Guardar los puntos en PlayerPrefs
        PlayerPrefs.SetInt("PuntosTotales", puntosTotales);
        PlayerPrefs.SetInt("PuntosArquero", puntosArquero);
        PlayerPrefs.SetInt("PuntosBarbaro", puntosBarbaro);
        PlayerPrefs.Save();
    }

    public void PlayerDied()
    {
        isPlayerDead = true;
        CheckGameOver();
    }

    public void Player2Died()
    {
        isPlayer2Dead = true;
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (isPlayerDead && isPlayer2Dead)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Abrir menu game over");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GuardarPuntos();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        GuardarPuntos();
        SceneManager.LoadScene("MenuInicial");
    }

    private void OnApplicationQuit()
    {
        // Elimina la clave de sesión al cerrar el juego
        PlayerPrefs.DeleteKey("SesionIniciada");
        PlayerPrefs.Save();
    }

    public void EndVS()
    {
        GuardarPuntos();
        SceneManager.LoadScene("VSWin");
    }
}



