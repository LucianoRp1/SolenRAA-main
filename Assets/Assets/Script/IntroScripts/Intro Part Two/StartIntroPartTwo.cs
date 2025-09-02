using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntroPartTwo : MonoBehaviour
{
    public GameObject panelOne;
    private ClosePanelPartOne finalIntroPartOne;

    public GameObject notification;
    public bool initIntroPartTwo = false;

    private void Awake()
    {
        finalIntroPartOne = panelOne.GetComponent<ClosePanelPartOne>();

    }

    private void Start()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if (finalIntroPartOne.finishPanelOne == true)
        {
            initIntroPartTwo = true;
            
        }

        if (initIntroPartTwo)
        {
            EnableNotification();
            initIntroPartTwo = false; 
        }
    }

    public void EnableNotification()
    {
        notification.SetActive(true);

    }
}
