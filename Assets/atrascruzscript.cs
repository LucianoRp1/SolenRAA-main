using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscenaAnterior : MonoBehaviour
{
    private static string escenaAnterior = "";

    void Awake()
    {
        string actual = SceneManager.GetActiveScene().name;
        if (actual != "jugarmapa")
        {
            escenaAnterior = actual;
        }
    }

    public void VolverAEscenaAnterior()
    {
        if (!string.IsNullOrEmpty(escenaAnterior))
        {
            SceneManager.LoadScene(escenaAnterior);
        }
        else
        {
            SceneManager.LoadScene("jugarmapa");
        }
    }
}

