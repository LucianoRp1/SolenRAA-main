using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscenaInvestigacion : MonoBehaviour
{
    // Esta función se puede usar desde cualquier escena para cargar "Investigacion"
    public void CargarEscenaInvestigacion()
    {
        SceneManager.LoadScene("Investigacion");
    }
}
