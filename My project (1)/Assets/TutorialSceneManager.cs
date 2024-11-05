using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del mouse
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Carga la siguiente escena en el índice de las escenas del Build Settings
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

