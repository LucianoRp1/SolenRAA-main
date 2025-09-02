using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLocationSanMartin : MonoBehaviour
{
    public Animator animLocation;
    public GameObject panelSolen;


    public void OnPressLocation()
    {
        animLocation.SetBool("isPressLocation", true);
        Debug.Log("si se preciono la plaza");
    }

    
    public void EventAnimatorLocation()
    {
        panelSolen.SetActive(true);
        gameObject.SetActive(false);
    }
}
