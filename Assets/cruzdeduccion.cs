using UnityEngine;
using UnityEngine.SceneManagement;

public class IrADeduccion : MonoBehaviour
{
    // Llamá esta función desde un botón u otro evento para ir a la escena "Deduccion"
    public void CargarEscenaDeduccion()
    {
        SceneManager.LoadScene("Deduccion");
    }
}
