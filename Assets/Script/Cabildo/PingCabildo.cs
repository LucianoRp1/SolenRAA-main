using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingCabildo : MonoBehaviour
{
    public Animator animPingCabildo;
    public GameObject iconAlertReliquia;


    public void OnPressPingCabildo()
    {
        animPingCabildo.SetBool("isPressCabildo", true);
    }

    public void EnableIconAlert()
    {
        iconAlertReliquia.SetActive(true);
        gameObject.SetActive(false);
    }
}
