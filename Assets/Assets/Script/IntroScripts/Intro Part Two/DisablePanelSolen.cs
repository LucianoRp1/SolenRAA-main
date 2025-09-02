using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePanelSolen : MonoBehaviour
{
    public GameObject panelSolenEnd;

    public GameObject iconPlazaSanMartin;


    void DisableSolenPanel()
    {
        panelSolenEnd.SetActive(false);
        iconPlazaSanMartin.SetActive(true);
    }
}
