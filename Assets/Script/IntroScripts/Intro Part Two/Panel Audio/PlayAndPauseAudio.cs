using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndPauseAudio : MonoBehaviour
{
    public AudioSource audioGeneral;
    public GameObject playButton;
    public GameObject pauseButton;

    public GameObject audioControllerTwo;
    private PlayAndPauseAudioTwo playControllerTwo;


    private void Awake()
    {
        playControllerTwo = audioControllerTwo.GetComponent<PlayAndPauseAudioTwo>();
    }
    private void Update()
    {
        
        if (!audioGeneral.isPlaying && audioGeneral.time >= audioGeneral.clip.length)
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }

    }

    public void PlayAudio()
    {
        audioGeneral.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        playControllerTwo.PauseAudio();
    }

    public void PauseAudio()
    {
        audioGeneral.Pause();
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

}
