using UnityEngine;
using UnityEngine.SceneManagement;

public class VerCarta : MonoBehaviour
{
    public void IrACartaCerrada()
    {
        SceneManager.LoadScene("carta cerrada");
    }
}
