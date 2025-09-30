using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIntro : MonoBehaviour
{

    public Camera camara;
    private FastGlitch efectoGlitch;
    private DigitalGlitch digitalGlitchKino;
    public GameObject introPanel;
    public float timeGlitch = 0;
    public float timePanel = 0;

    void Start()
    {


        efectoGlitch = camara.GetComponent<FastGlitch>();
        digitalGlitchKino = camara.GetComponent<DigitalGlitch>();
        introPanel.SetActive(false);

        StartCoroutine(ActivarEfectoConRetraso(timeGlitch));
        StartCoroutine(ActivateIntroPanel(timePanel));
    }




    IEnumerator ActivarEfectoConRetraso(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        if (efectoGlitch != null)
        {
            efectoGlitch.enabled = true;
            digitalGlitchKino.enabled = true;
        }
        else
        {
            Debug.LogWarning("FastGlitch no se encontró en la cámara");
        }
    }

    IEnumerator ActivateIntroPanel(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        introPanel.SetActive(true);
    }



}
