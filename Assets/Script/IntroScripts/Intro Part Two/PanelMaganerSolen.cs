using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelMaganerSolen : MonoBehaviour
{

    [Header("Intro Finish")]
    [SerializeField] IntroState introState;

    [Header("Panel Solen")]
    public GameObject panelSolen;

    [Header("Arrastra aquí tus paneles")]
    public GameObject[] panels;

    [Header("Arrastra aquí los textos dentro de cada panel")]
    public GameObject[] textsPanels;

    private TypingEffect typingEffect;
    private int currentIndex = 0;

    [Header("Botones")]
    public Button buttonNext;
    public Button buttonAceptar;
    public Button buttonAceptarTwo;
    public Button buttonAceptarThree;
    public Button buttonAceptarFour;
    public Button buttonAceptarFive;
    public Button buttonAceptarSix;

    [Header("Ping San Martin")]
    public GameObject pinSanMartin;
    private PingSanMartin sanMarinPing;

    [Header("Panel Anterior Audio")]
    public GameObject content5;
    public GameObject textPanel5;
    private TypingEffect typingEffectContent5;

    [Header("Audio Spectrum")]
    public GameObject contentAudioOne;
    public GameObject primerAudioLength;
    private AudioSlider primerAudioSliderController;

    [Header("Panel Siguiente Audio")]
    public GameObject content6;
    public GameObject textPanel6;
    private TypingEffect typingEffectContent6;


    [Header("Audio SpectrumTwo")]
    public GameObject contentAudioTwo;
    public GameObject segundoAudioLength;
    private AudioSlider segundoAudioSliderController;


    [Header("Panel Siguiente Audio Two")]
    public GameObject content7;
    public GameObject textPanel7;
    private TypingEffect typingEffectContent7;


    private bool metodCheckTypingEffect = false;

    [Header("Animator")]
    public Animator animPanel;
    public Animator[] subPanels;
    public Animator[] secondsubPanels;

    [Header("Intro Scrit Part Two")]
    public GameObject introScriptPartTwo;

    [Header("Intro Manager Part One")]
    public GameObject introManagerPartOne;

    public bool isAceptMission = false;



    private void Start()
    {
        // Activar primer panel
        panels[currentIndex].SetActive(true);
        typingEffect = textsPanels[currentIndex].GetComponent<TypingEffect>();

        // Referencias
        sanMarinPing = pinSanMartin.GetComponent<PingSanMartin>();
        typingEffectContent5 = textPanel5.GetComponent<TypingEffect>();
        typingEffectContent6 = textPanel6.GetComponent<TypingEffect>();
        typingEffectContent7 = textPanel7.GetComponent<TypingEffect>();
        primerAudioSliderController = primerAudioLength.GetComponent<AudioSlider>();
        segundoAudioSliderController = segundoAudioLength.GetComponent<AudioSlider>();

        

        // Estados iniciales
        buttonNext.interactable = false;
        buttonAceptar.gameObject.SetActive(false);
        buttonAceptarTwo.interactable = false;
        buttonAceptarTwo.gameObject.SetActive(false);
        buttonAceptarThree.gameObject.SetActive(false);

        pinSanMartin.SetActive(false);
        contentAudioOne.SetActive(false);
        content5.SetActive(false);
 
    }

    private void Update()
    {
       
        CheckTypingEffect();
        CheckSanMartinPing();
        CheckAudio();
        CheckContent6();
        CheckAudioTwo();
        CheckContent7();
    }


    private void CheckTypingEffect()
    {
        if (metodCheckTypingEffect) return;
        if (typingEffect != null && typingEffect.textEnd)
        {
            buttonNext.interactable = true;
        }
        else
        {
            buttonNext.interactable = false;
        }

        if (IsLastPanel() && typingEffect.textEnd)
        {
            buttonNext.interactable = false;
            buttonNext.gameObject.SetActive(false);

            buttonAceptar.interactable = true;
            buttonAceptar.gameObject.SetActive(true);
            metodCheckTypingEffect = true;
        }
        
        
    }

    private void CheckSanMartinPing()
    {
        if (sanMarinPing.isPressPingSanMartin)
        {
            content5.SetActive(true);
        }
        if (typingEffectContent5.textEnd)
        {
            buttonAceptarTwo.interactable = true;
        }
    }

    private void CheckAudio()
    {
        if (primerAudioSliderController.finishAudio)
        {
            buttonAceptarThree.interactable = true;
            
           
        }
    }


    public void CheckContent6()
    {
        if (typingEffectContent6.textEnd)
        {
            buttonAceptarFour.interactable = true;
        }
    }



    public void CheckAudioTwo()
    {
        if (segundoAudioSliderController.finishAudio)
        {
            buttonAceptarFive.interactable = true;
        }
    }

    public void CheckContent7()
    {
        if (typingEffectContent7.textEnd)
        {
            buttonAceptarSix.interactable = true;
        }
    }

    public void ActivateNextPanel()
    {
        currentIndex++;

        if (currentIndex < panels.Length)
        {
            panels[currentIndex].SetActive(true);
            typingEffect = textsPanels[currentIndex].GetComponent<TypingEffect>();
            buttonNext.interactable = false;
        }
        else
        {
            buttonNext.interactable = false;
        }
    }




    public void AceptarMessageSolen()
    {
       // panelSolen.SetActive(false);
        animPanel.SetBool("endPanelSolen", true);
        pinSanMartin.SetActive(true);
        buttonAceptar.gameObject.SetActive(false);
        buttonAceptarTwo.gameObject.SetActive(true);

        EventCloseAllSubPanels();
       // introState.introEnded = true;

    }

    public void ClosePanelEvent()
    {
        panelSolen.SetActive(false);
       // Debug.Log("donde se ejecutaesto");
    }

    public void EventCloseAllSubPanels()
    {
        foreach (Animator anim in subPanels)
        {
            anim.SetBool("closeAllSubsPanels", true);
        }
    }

    public void ListenAudio()
    {
        buttonAceptarTwo.gameObject.SetActive(false);
        buttonAceptarThree.gameObject.SetActive(true);
        
        contentAudioOne.SetActive(true);
       
    }

    public void OpcionalPanel()
    {
        buttonAceptarThree.gameObject.SetActive(false );
        content6.SetActive(true);
        buttonAceptarFour.gameObject.SetActive(true);
    }

    public void ListenAudioTwo()
    {
        buttonAceptarFour.gameObject.SetActive(false);
        contentAudioTwo.SetActive(true);
        buttonAceptarFive.gameObject.SetActive(true);
    }
    

    public void LastPanelSeven()
    {
        buttonAceptarFive.gameObject.SetActive(false) ;
        content7.SetActive(true);
        buttonAceptarSix.gameObject.SetActive(true);
    }

    public void AceptMissionSolen()
    {
        introManagerPartOne.SetActive(false);
        isAceptMission = true;
        introState.introEnded = true;
        PlayerPrefs.SetInt("IntroEnded", 1);
        PlayerPrefs.Save();
        animPanel.SetBool("endPanelSolen", true);
        buttonAceptarSix.gameObject.SetActive(false);
        EventCloseAllSecondSubPanels();
        EventCloseAllSubPanels();

    }


    public void EventCloseAllSecondSubPanels()
    {
        foreach (Animator anim in secondsubPanels)
        {
            anim.SetBool("closeAllSubsPanels", true);
        }
    }
    private bool IsLastPanel()
    {
        return currentIndex == panels.Length - 1;
    }
}
