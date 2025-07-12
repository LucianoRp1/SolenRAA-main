using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBackButton : MonoBehaviour
{
    public void GoToExploracion()
    {
        string sceneName = "Exploracion"; // Nombre exacto de la escena a la que quieres ir
        Debug.Log("Cambiando de escena a: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
