using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Button playPauseButton;
    public Slider progressBar;

    [Header("Icons")]
    public Sprite playIcon;
    public Sprite pauseIcon;

    [Header("Audio")]
    public AudioClip audioClip;

    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        // Configurar AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;

        // Comprobar que los objetos UI estén asignados
        if (playPauseButton == null) Debug.LogError("playPauseButton no asignado!");
        if (progressBar == null) Debug.LogError("progressBar no asignado!");
        if (playIcon == null || pauseIcon == null) Debug.LogError("Iconos no asignados!");
        if (audioClip == null) Debug.LogError("AudioClip no asignado!");

        // Configurar botón si está asignado
        if (playPauseButton != null)
        {
            playPauseButton.onClick.AddListener(TogglePlayPause);
            if (playIcon != null)
                playPauseButton.image.sprite = playIcon;
        }

        // Configurar barra de progreso si está asignada
        if (progressBar != null)
        {
            progressBar.minValue = 0f;
            progressBar.maxValue = 1f;
            progressBar.value = 0f;
            progressBar.onValueChanged.AddListener(SeekAudio);
        }
    }

    void Update()
    {
        if (audioSource.clip != null && isPlaying && progressBar != null)
        {
            // Actualizar barra
            progressBar.value = Mathf.Clamp01(audioSource.time / audioSource.clip.length);

            // Cuando termine, volver al estado inicial
            if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
            {
                if (playPauseButton != null && playIcon != null)
                    playPauseButton.image.sprite = playIcon;

                isPlaying = false;
                progressBar.value = 0f;
            }
        }
    }

    void TogglePlayPause()
    {
        if (audioSource.clip == null) return;

        if (isPlaying)
        {
            audioSource.Pause();
            if (playPauseButton != null && playIcon != null)
                playPauseButton.image.sprite = playIcon;

            isPlaying = false;
        }
        else
        {
            audioSource.Play();
            if (playPauseButton != null && pauseIcon != null)
                playPauseButton.image.sprite = pauseIcon;

            isPlaying = true;
        }
    }

    void SeekAudio(float value)
    {
        if (audioSource.clip == null || progressBar == null) return;

        // Limitar el tiempo para que no se pase del audio
        float seekTime = Mathf.Clamp(value * audioSource.clip.length, 0f, audioSource.clip.length - 0.01f);
        audioSource.time = seekTime;
    }
}
