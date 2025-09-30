using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndPauseAudioTwo : MonoBehaviour
{
    public AudioSource audioGeneralTwo;
    public GameObject playButton;
    public GameObject pauseButton;

    public GameObject segundoAudioLength;
    private AudioSlider segundoAudioSlider;


    public GameObject audioController;
    private PlayAndPauseAudio playController;
    private void Awake()
    {
        segundoAudioSlider = segundoAudioLength.GetComponent<AudioSlider>();
        playController = audioController.GetComponent<PlayAndPauseAudio>();
    }
    private void Update()
    {

        if (!audioGeneralTwo.isPlaying && segundoAudioSlider.finishAudio)
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }

    }

    public void PlayAudio()
    {
        audioGeneralTwo.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        playController.PauseAudio();
    }

    public void PauseAudio()
    {
        audioGeneralTwo.Pause();
        playButton.SetActive(true);
        pauseButton.SetActive(false);

    }

}
