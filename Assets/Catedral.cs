using UnityEngine;
using UnityEngine.SceneManagement;

public class IrACatedral : MonoBehaviour
{
    // Esta función se puede llamar desde un botón o cualquier otro evento
    public void CargarEscenaCatedral()
    {
        SceneManager.LoadScene("Catedral");
    }
}
