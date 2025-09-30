using UnityEngine;
using UnityEngine.SceneManagement;

public class IrInves: MonoBehaviour
{
    // Esta función se puede usar desde cualquier escena para cargar "Investigacion"
    public void CargarEscenaInvestigacion()
    {
        SceneManager.LoadScene("investigacion");
    }
}
