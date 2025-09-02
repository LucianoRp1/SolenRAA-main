using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscenaFija : MonoBehaviour
{
    public string nombreEscena; // Asignás esto desde el Inspector

    public void CargarEscena()
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogError("El nombre de la escena está vacío.");
        }
    }
}
