using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Esta función debe estar conectada al botón en el Inspector
    public void CambiarAEscenaCronografo()
    {
        if (SceneManager.GetActiveScene().name == "Investigacion")
        {
            SceneManager.LoadScene("Cronografo");
        }
        else
        {
            Debug.Log("No estás en la escena de investigación.");
        }
    }
}
