using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelPartOne : MonoBehaviour
{
    public GameObject panelIntroPartOne;
    public Camera camara;
    private FastGlitch fastGlitch;
    public bool finishPanelOne = false;


    private void Awake()
    {
        fastGlitch = camara.GetComponent<FastGlitch>();
    }

    private void Start()
    {
        finishPanelOne = false ;
    }
    public void ClosePanelIntroPartOne()
    {
        panelIntroPartOne.SetActive(false);
        fastGlitch.enabled = false; 
        finishPanelOne= true ;
        Debug.Log("se tiene que poner true");
    }
}
