using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscenaJurar : MonoBehaviour
{
    // Esta función carga la escena llamada "Jurar"
    public void CargarEscenaJurar()
    {
        SceneManager.LoadScene("Jurar");
    }
}
