using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccepMessageSolen : MonoBehaviour
{
    private PanelNavigator panelNav;
    public GameObject panelNavSolen;


    public Animator animPanelSolen;




    private void Awake()
    {
        panelNav = panelNavSolen.GetComponent<PanelNavigator>();
    }


    private void Update()
    {
        if (panelNav.isButtonAceptar)
        {
            panelNav.isButtonAceptar = false; // lo reseteo
            AceptarMensajeSolen();
        }
    }



    public void AceptarMensajeSolen()
    {
        animPanelSolen.SetBool("endPanelSolen", true);
    }

    //public void ActionButtonAccep()
    //{
    //    animPanelSolen.SetBool("endPanelSolen",true);
    //}
}
