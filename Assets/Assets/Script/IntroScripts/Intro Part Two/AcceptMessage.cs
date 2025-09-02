using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptMessage : MonoBehaviour
{
    public Animator animNotification;

    public GameObject panelSolen;


    private void Start()
    {
        panelSolen.SetActive(false);
    }
    public void IsPressButtonMessage()
    {
        animNotification.SetBool("isPressButton", true);
    }

    public void EnablePanelSolen()
    {
        panelSolen.SetActive(true);
    }
}
