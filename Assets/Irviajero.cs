using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarIns : MonoBehaviour
{
    // Esta función la podés llamar desde un botón o evento
    public void IrAViajeroPorElTiempo()
    {
        SceneManager.LoadScene("Viajero por el tiempo");
    }
}
