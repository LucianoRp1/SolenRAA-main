using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptConnection : MonoBehaviour
{
    public Animator animPanelIntro;
    public void EndAnimatior()
    {
        animPanelIntro.SetBool("endAnimation", true);
       
    }   
}
