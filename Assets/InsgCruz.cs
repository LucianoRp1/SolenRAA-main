using UnityEngine;
using UnityEngine.SceneManagement;

public class InsgCruz : MonoBehaviour
{
    public void IrAJugarMapa()
    {
        Debug.Log("Intentando cargar escena: jugarmapa");
        SceneManager.LoadScene("jugarmapa");
    }
}
