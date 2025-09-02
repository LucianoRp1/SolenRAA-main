using UnityEngine;

public class BotonSonido : MonoBehaviour
{
    public AudioSource audioSource;   // El componente que reproduce el audio
    public AudioClip sonidoBoton;     // El clip de audio

    // Método para el botón "Escuchar"
    public void ReproducirSonido()
    {
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.clip = sonidoBoton; // Asigna el clip
            audioSource.Play();             // Reproduce
        }
    }

    // Método para el botón "Pausa"
    public void PararSonido()
    {
        if (audioSource != null)
        {
            audioSource.Stop();  // Detiene el audio
        }
    }
}
