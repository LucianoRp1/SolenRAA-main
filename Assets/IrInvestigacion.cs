using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarAEscenaInvestigacion : MonoBehaviour
{
    // Llama esta función para cambiar de escena
    public void IrAEscenaInvestigacion()
    {
        SceneManager.LoadScene("investigacion");
    }
}
