using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscenaDeduccion : MonoBehaviour
{
    // Esta función puede ser llamada desde un botón en cualquier escena
    public void CargarEscenaDeduccion()
    {
        SceneManager.LoadScene("Deduccion");
    }
}
