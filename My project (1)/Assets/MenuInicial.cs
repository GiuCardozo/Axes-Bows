using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Toma la escena actual y le suma uno para pasar a la siguiente
    }

    public void Lenguaje()
    {
        Debug.Log("Cambio de idioma");
    }
}
