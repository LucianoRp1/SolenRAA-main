using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIntroPartTwo : MonoBehaviour
{
    public GameObject panelOne;
    private ClosePanelPartOne closePanelOne;

    public GameObject notification;
    private NotificationSolen notificationSolen;


    public GameObject panelTwoSolen;
   

    private bool alreadyTriggered = false;

    public float time = 0;

    public bool isUsedMetod = false;    

    private void Awake()
    {
        closePanelOne = panelOne.GetComponent<ClosePanelPartOne>();
        notificationSolen = notification.GetComponent<NotificationSolen>();
        //notification.SetActive(false);
    }

    private void Update()
    {
        if (closePanelOne.finishPanelOne && !alreadyTriggered)
        {
            alreadyTriggered = true;
            Invoke(nameof(InitNotification), time);
        }

        if (notificationSolen.aceptNotification)
        {
            CloseNotificationEnablePanelSolen();
        }
    }

    void InitNotification()
    {
        notification.SetActive(true);
    }


    void CloseNotificationEnablePanelSolen()
    {
        if (isUsedMetod) return;
        notification.SetActive(false);
        panelTwoSolen.SetActive(true);
        isUsedMetod = true;
    }
}
