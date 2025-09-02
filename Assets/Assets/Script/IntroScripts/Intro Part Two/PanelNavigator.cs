using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelNavigator : MonoBehaviour
{
    public GameObject[] panels;   // Tus 4 paneles en orden
    private int currentIndex = 0; // Panel actual

    public GameObject[] textPanels;
    private TypingEffect typingEffect;

    public Button nextButton;
    public Button prevButton;

    public GameObject textSiguiente;
    public GameObject textAceptar;


    public bool isButtonAceptar=false;

    void Start()
    {
        ShowPanel(currentIndex); // Muestra el primero al inicio
        typingEffect = textPanels[currentIndex].GetComponent<TypingEffect>();
        nextButton.interactable = false;
        prevButton.interactable = false;
        textAceptar.SetActive(false);
    }


    public void Update()
    {
        int textPanelIndex = System.Array.IndexOf(textPanels, typingEffect.gameObject);
        
        if (typingEffect != null && typingEffect.textEnd)
        {
            Debug.Log("si termino avanza");
            nextButton.interactable = true;

            typingEffect = textPanels[currentIndex].GetComponent<TypingEffect>();

            // solo habilitar prevButton si NO estamos en el primer panel
            prevButton.interactable = (currentIndex > 0);


            if (currentIndex == panels.Length - 1)
            {
                textAceptar.SetActive(true);
                textSiguiente.SetActive(false);
                isButtonAceptar = true;
            }
            else
            {
                textAceptar.SetActive(false);
                textSiguiente.SetActive(true);
                isButtonAceptar = false;
            }

  
        }


        else
        {
           
            nextButton.interactable = false;
            prevButton.interactable = false;

            // el prev solo se apaga si estamos en el primer panel
            if (currentIndex == 0)
                prevButton.interactable = false;
        }

        
    }
    public void NextPanel()
    {
        if (currentIndex < panels.Length - 1)
        {
            currentIndex++;
            ShowPanel(currentIndex);
        }
    }



    public void PreviousPanel()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowPanel(currentIndex);

            //  También actualizar typingEffect
            typingEffect = textPanels[currentIndex].GetComponent<TypingEffect>();
        }

    }

    private void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
    }



}
