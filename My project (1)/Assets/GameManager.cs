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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verificar si la escena es "Modo Coop" o "ModoVS"
        if (scene.name == "Modo Coop" || scene.name == "ModoVS")
        {
            ResetearPuntos(); // Reiniciar los puntos al cargar "Modo Coop" o "ModoVS"
        }
    }

    private void ResetearPuntos()
    {
        puntosTotales = 0;
        puntosArquero = 0;
        puntosBarbaro = 0;
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
        PlayerPrefs.DeleteKey("SesionIniciada");
        PlayerPrefs.Save();
    }

    public void EndVS()
    {
        GuardarPuntos();
        SceneManager.LoadScene("VSWin");
    }
}




