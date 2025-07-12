using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMessage : MonoBehaviour
{
    public GameObject PanelButton;
    public GameObject PanelMessage;


   public void ManagerPanels()
    {
        PanelButton.SetActive(false);
        PanelMessage.SetActive(true);
    }
}
