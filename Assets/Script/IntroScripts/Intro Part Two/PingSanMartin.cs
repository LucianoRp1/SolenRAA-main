using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingSanMartin : MonoBehaviour
{
    public Animator animPing;

    public bool isPressPingSanMartin = false;


    public GameObject panelSolen;
    public void PressIconSanMartin()
    {
        animPing.SetBool("isPressLocation", true);
    }


    public void EventFinishPingSanMartin()
    {
        gameObject.SetActive(false);

        isPressPingSanMartin = true;
        panelSolen.SetActive(true);
    }
}
