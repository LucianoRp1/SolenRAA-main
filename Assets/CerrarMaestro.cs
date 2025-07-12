using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;

public class CerrarMaestro : MonoBehaviour
{
    public void CerrarEscenaYVolverAJugarMapa()
    {
        // Cargar JugarMapa antes de descargar Maestro
        SceneManager.LoadScene("JugarMapa");

        // Esperar un pequeño momento antes de descargar Maestro
        StartCoroutine(EsperarYDescargar());
    }

    private IEnumerator EsperarYDescargar()
    {
        yield return new WaitForSeconds(0.1f); // Pequeño delay para que JugarMapa cargue bien
        SceneManager.UnloadSceneAsync("Maestro");
    }
}
