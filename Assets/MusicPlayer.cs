using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    private AudioSource audioSource;
    public float fadeDuration = 2f; // Duración del fade en segundos

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Subir volumen gradualmente
    public void MaxVolume()
    {
        StopAllCoroutines(); // Evita que se mezclen fades
        StartCoroutine(FadeVolume(audioSource.volume, 1f));
    }

    // Bajar volumen gradualmente
    public void MinVolume()
    {
        StopAllCoroutines();
        StartCoroutine(FadeVolume(audioSource.volume, 0.25f));
    }

    private IEnumerator FadeVolume(float start, float end)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, end, elapsed / fadeDuration);
            yield return null;
        }
        audioSource.volume = end; // Asegura que quede exactamente en el valor final
    }
}
