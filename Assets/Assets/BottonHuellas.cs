using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonHuellas : MonoBehaviour
{
    [SerializeField] private string nombreEscenaDestino = "Huellas en el pasaje";

    public void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}
