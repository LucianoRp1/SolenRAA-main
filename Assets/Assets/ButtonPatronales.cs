using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Método para cargar la escena Patronales
    public void LoadPatronales()
    {
        SceneManager.LoadScene("Patronales");
    }
}
