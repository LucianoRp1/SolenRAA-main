using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerIntros : MonoBehaviour
{
    [Header("Intro Finish")]
    [SerializeField] IntroState introState;
    public GameObject introPanelManagerPartOne;
    public GameObject introPanelManagerPartTwo;

    [Header("Music")]
    public GameObject musicPrefab;
    private MusicPlayer musicPlayer;

    [Header("Panel Solen")]
    public GameObject panelSolen;


    [Header("Panel Block Buttons")]
    public GameObject panelsBlockTop;
    public GameObject panelsBlockBottom;
    private CanvasGroup topCanvasGroup;
    private CanvasGroup bottomCanvasGroup;

    private void Awake()
    {
        topCanvasGroup = panelsBlockTop.GetComponent<CanvasGroup>();
        bottomCanvasGroup = panelsBlockBottom.GetComponent<CanvasGroup>();

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

    private void Start()
    {
        bool alreadyEnded = PlayerPrefs.GetInt("IntroEnded", 0) == 1;
        if (alreadyEnded || introState.introEnded)
        {
            introPanelManagerPartOne.SetActive(false);
            introPanelManagerPartTwo.SetActive(false);
            UnblockButtons();
        }
        else
        {
            // Si no terminó la intro, bloqueamos
            BlockButtons();
        }
    }
    private void Update()
    {
        CheckMinVolume();
        CheckMaxVolume();
        if (introState.introEnded)
        {
            UnblockButtons();
        }
    }


    public void UnblockButtons()
    {
        topCanvasGroup.interactable = true;
        topCanvasGroup.blocksRaycasts = true;

        bottomCanvasGroup.interactable = true;
        bottomCanvasGroup.blocksRaycasts = true;
    }

    public void BlockButtons()
    {
        topCanvasGroup.interactable = false;
        topCanvasGroup.blocksRaycasts = false;

        bottomCanvasGroup.interactable = false;
        bottomCanvasGroup.blocksRaycasts = false;
    }
    public void CheckMinVolume()
    {
        if (panelSolen.activeInHierarchy)
        {
            musicPlayer.MinVolume();
        }


    }

    public void CheckMaxVolume()
    {
        if (!panelSolen.activeInHierarchy)
        {
            musicPlayer.MaxVolume();
        }
    }
}
