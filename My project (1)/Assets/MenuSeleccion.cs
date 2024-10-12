using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSeleccion : MonoBehaviour
{
    public void Cooperativo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Versus()
    {
        Debug.Log("Iniciar modo VS...");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
