using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationSolen : MonoBehaviour
{
    public Animator animNotification;
    public bool aceptNotification= false;

    private void Start()
    {
        aceptNotification = false;
    }
    public void AceptNotification()
    {
        animNotification.SetBool("isPressButton", true);
       // aceptNotification= true;
        //gameObject.SetActive(false);
    }

    public void CloseNotification()
    {
        gameObject.SetActive(false);
        aceptNotification = true;
    }
}
