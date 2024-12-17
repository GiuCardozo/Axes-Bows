using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Aseg�rate de importar SceneManagement

public class GoogleLogin : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;
    public Text statusText;

    void Start()
    {
        // Inicializa Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }

    // M�todo para iniciar sesi�n con Google
    public void OnGoogleSignIn()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // Llamamos a la funci�n JavaScript definida en firebase-auth.js
            Application.ExternalCall("googleSignIn");
#else
        statusText.text = "Google Sign-In is only available in WebGL build!";
        Debug.LogWarning("Google Sign-In is only available in WebGL build!");
#endif
    }

    // Este m�todo puede ser llamado desde JavaScript despu�s de que el login de Google sea exitoso
    public void OnGoogleSignInCallback(string idToken, string accessToken)
    {
        // Crear las credenciales de Firebase con los tokens recibidos de Google
        Credential credential = GoogleAuthProvider.GetCredential(idToken, accessToken);

        // Iniciar sesi�n con Firebase usando las credenciales de Google
        auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(authTask => {
            if (authTask.IsCompleted && !authTask.IsFaulted && authTask.Result != null)
            {
                user = authTask.Result;
                statusText.text = "Login successful! Welcome, " + user.DisplayName;
                Debug.Log("User logged in: " + user.Email);

                // Cargar la siguiente escena despu�s de iniciar sesi�n exitosamente
                SceneManager.LoadScene("MenuInicial");  // Reemplaza "NextSceneName" con el nombre de tu escena
            }
            else
            {
                statusText.text = "Login failed!";
                Debug.LogError("Login failed: " + authTask.Exception);
            }
        });
    }
}
