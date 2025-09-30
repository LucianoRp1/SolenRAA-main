using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoundPrefab : MonoBehaviour
{
    [Header("Music")]
    public GameObject musicPrefab;
    private MusicPlayer musicPlayer;

    [Header("IntroPartOne")]
    public GameObject introPartOnePanel;



    private void Awake()
    {
        if (MusicPlayer.instance == null)
        {
            GameObject musicObj = Instantiate(musicPrefab);
            musicPlayer = musicObj.GetComponent<MusicPlayer>();
        }
        else
        {
            musicPlayer = MusicPlayer.instance;
        }
    }

    private void Update()
    {
        CheckMinAudio();
        CheckMaxAudio();
    }



    void CheckMinAudio()
    {
        if (introPartOnePanel.activeInHierarchy)
        {
            musicPlayer.MinVolume();
        }
    }

    void CheckMaxAudio()
    {
        if (!introPartOnePanel.activeInHierarchy)
        {
            musicPlayer.MaxVolume();
        }
    }
}
