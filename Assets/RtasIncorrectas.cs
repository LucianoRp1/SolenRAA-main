using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class CartelIncorrectoManager : MonoBehaviour
{
    public GameObject cartelIncorrecto;
    public GameObject[] botonesRespuestas;
    public GameObject botonPrincipal;

    public void MostrarCartelIncorrecto(GameObject botonPresionado)
    {
        cartelIncorrecto.SetActive(true);

        // Ocultar el botón presionado
        if (botonPresionado != null)
            botonPresionado.SetActive(false);

        // Ocultar los demás botones
        foreach (GameObject boton in botonesRespuestas)
        {
            boton.SetActive(false);
        }

        // Ocultar el botón principal
        if (botonPrincipal != null)
            botonPrincipal.SetActive(false);
    }

    public void OcultarCartelIncorrecto()
    {
        cartelIncorrecto.SetActive(false);

        // Volver a mostrar todos los botones
        foreach (GameObject boton in botonesRespuestas)
        {
            boton.SetActive(true);
        }

        if (botonPrincipal != null)
            botonPrincipal.SetActive(true);
    }

    // 👉 Función para el botón Aceptar: cierra cartel y va a la escena
    public void AceptarYCambiarEscena()
    {
        cartelIncorrecto.SetActive(false); // Ocultar cartel
        SceneManager.LoadScene("insg");    // Ir a la escena
    }
}
