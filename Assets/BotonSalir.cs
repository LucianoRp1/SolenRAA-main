using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour
{
    public void VolverAJugarMapa()
    {
        SceneManager.LoadScene("jugarmapa"); 
    }
}
