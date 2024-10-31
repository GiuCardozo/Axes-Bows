using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinSceneManager : MonoBehaviour
{
    public TextMeshProUGUI puntosArqueroText;
    public TextMeshProUGUI puntosBarbaroText;
    public GameObject Arquero;
    public GameObject Barbaro;
    public GameObject Apoints;
    public GameObject Bpoints;

    private void Start()
    {
        // Recuperar los puntos de PlayerPrefs
        int puntosArquero = PlayerPrefs.GetInt("PuntosArquero", 0);
        int puntosBarbaro = PlayerPrefs.GetInt("PuntosBarbaro", 0);

        if (puntosArquero > puntosBarbaro)
        {
            Arquero.SetActive(true);
            puntosArqueroText.text = "Puntos: " + puntosArquero;
            Apoints.SetActive(true);
        }
        else
        {
            Barbaro.SetActive(true);
            puntosBarbaroText.text = "Puntos: " + puntosBarbaro;
            Bpoints.SetActive(true);
        }
    }

    public void Return()
    {
        // Restablecer los puntos en PlayerPrefs
        PlayerPrefs.SetInt("PuntosTotales", 0);
        PlayerPrefs.SetInt("PuntosArquero", 0);
        PlayerPrefs.SetInt("PuntosBarbaro", 0);
        PlayerPrefs.Save(); // Asegura que los cambios se guarden inmediatamente

        // Cargar la escena "MenuInicial"
        SceneManager.LoadScene("MenuInicial");
    }
}


