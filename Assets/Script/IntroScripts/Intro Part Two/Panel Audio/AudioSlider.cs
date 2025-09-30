using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    public bool audiosIsEnd = false;
    public bool finishAudio = false;

    void Start()
    {
        if (audioSource.clip != null)
            slider.maxValue = audioSource.clip.length;
    }

    void Update()
    {
        // Actualiza el slider mientras el audio se reproduce
        if (audioSource.isPlaying)
        {
            slider.value = audioSource.time;

            // Si se volvió a reproducir después de terminar, resetea el estado
            if (audiosIsEnd)
                audiosIsEnd = false;
        }

        // Detecta cuando el audio terminó y reinicia el slider solo una vez
        if (!audioSource.isPlaying &&
            audioSource.time >= audioSource.clip.length - 0.01f &&
            !audiosIsEnd)
        {
            
            audiosIsEnd = true;
            finishAudio = true;
            slider.value = 0; // Reinicia el slider una sola vez
        }
    }

    public void OnSliderValueChanged()
    {
        if (audioSource.clip == null) return; // Evita errores si no hay clip

        float newTime = Mathf.Clamp(slider.value, 0f, audioSource.clip.length);
        audioSource.time = newTime;

        // Si el usuario mueve el slider después del fin, habilita de nuevo el control
        if (audiosIsEnd)
            audiosIsEnd = false;
    }
}
