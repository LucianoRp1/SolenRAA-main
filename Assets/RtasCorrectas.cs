using UnityEngine;

public class CartelCorrectoManager : MonoBehaviour
{
    public GameObject cartelCorrecto; // El panel con el mensaje
    public GameObject[] botonesRespuestas; // Todos los botones de respuesta (correctos e incorrectos)
    public GameObject botonPrincipal; // Por ejemplo: "Comprobar", "Siguiente", etc.

    private GameObject botonCorrectoPresionado; // Para guardar el que se apretó

    // Llamar cuando se acierta
    public void MostrarCartelCorrecto(GameObject botonPresionado)
    {
        cartelCorrecto.SetActive(true);

        // Guardar el botón presionado
        botonCorrectoPresionado = botonPresionado;

        // Ocultar todos los botones de respuesta
        foreach (GameObject boton in botonesRespuestas)
        {
            boton.SetActive(false);
        }

        // Ocultar el botón principal si hay
        if (botonPrincipal != null)
        {
            botonPrincipal.SetActive(false);
        }
    }

    // Llamar al apretar "Aceptar"
    public void OcultarCartelCorrecto()
    {
        cartelCorrecto.SetActive(false);

        // Volver a activar todos los botones
        foreach (GameObject boton in botonesRespuestas)
        {
            boton.SetActive(true);
        }

        // Reactivar el botón principal
        if (botonPrincipal != null)
        {
            botonPrincipal.SetActive(true);
        }

        // Limpiar la referencia
        botonCorrectoPresionado = null;
    }
}
