using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }


    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f; //Detiene el juego
        menuPausa.SetActive(true); //activar el menu de pausa
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; //Reanuda la velocidad normal del juego
        menuPausa.SetActive(false); //desactivar menu de pausa
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Regresa el nombre de la escena donde nos encontramos actualmente
    }

    public void Salir()
    {
        Time.timeScale = 1f; //Reanudar la velocidad normal de la escena para que al regresar funcione correctamente
        SceneManager.LoadScene("MenuInicial"); //Volver al menú inicial
    }
}
