using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirMaestro : MonoBehaviour
{
    public void IrAMaestro()
    {
        SceneManager.LoadScene("Maestro"); // Asegúrate de que el nombre de la escena es correcto
    }
}
