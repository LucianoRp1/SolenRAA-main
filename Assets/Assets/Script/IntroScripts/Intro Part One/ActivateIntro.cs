using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIntro : MonoBehaviour
{
    public Camera camara; 
    private FastGlitch efectoGlitch;
    public GameObject introPanel;
   //
    public float time;

    void Start()
    {
        efectoGlitch = camara.GetComponent<FastGlitch>();
        introPanel.SetActive(false);
        //introPanel2.SetActive(false);

      
        StartCoroutine(ActivarEfectoConRetraso(time));
    }

    IEnumerator ActivarEfectoConRetraso(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        if (efectoGlitch != null)
        {
            efectoGlitch.enabled = true;
            introPanel.SetActive(true);
            
        }
        else
        {
            Debug.LogWarning("FastGlitch no se encontró en la cámara");
        }
    }
}
