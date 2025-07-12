using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSprite : MonoBehaviour
{
    public Image lineImage; 
    public float fillSpeed = 1f; 
    public float targetFill = 1f;


    public GameObject panelText;

    public bool isFull = false;
    private void Start()
    {
        lineImage.fillAmount = 0f;
        isFull = false;
    }

    private void Update()
    {
        if (lineImage.fillAmount < targetFill)
        {
            lineImage.fillAmount += fillSpeed * Time.deltaTime;

            if (lineImage.fillAmount >= targetFill)
            {
                isFull = true;
                lineImage.fillAmount = targetFill;
                Debug.Log("Panel está lleno!");
                if (isFull)
                {
                    panelText.SetActive(true);
                }
            }
        }
    }
}
