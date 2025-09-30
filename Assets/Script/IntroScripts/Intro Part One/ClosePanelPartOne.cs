using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelPartOne : MonoBehaviour
{
    public GameObject finishPanelIntroPartOne;
    public Camera camara;

    private FastGlitch fastGlitch;
    private DigitalGlitch digitalGlitchKino;

    public bool finishPanelOne = false;
    public float glitchSpeed = 1f; // Velocidad de aumento

    private void Awake()
    {
        fastGlitch = camara.GetComponent<FastGlitch>();
        digitalGlitchKino = camara.GetComponent<DigitalGlitch>();
    }

    private void Start()
    {
        finishPanelOne = false;
    }

    public void ClosePanelIntroPartOne()
    {
        finishPanelIntroPartOne.SetActive(false);
        fastGlitch.enabled = false;
        digitalGlitchKino.enabled = false;
        finishPanelOne = true;
    }

    public void AumentGlitch()
    {
        // Detenemos cualquier corutina previa para evitar solapamiento
        StopAllCoroutines();
        StartCoroutine(AumentarGradualmente());
    }

    private IEnumerator AumentarGradualmente()
    {
        float startValue = digitalGlitchKino.intensity; // Valor inicial actual
        float targetValue = 1f;                         // Máximo
        float t = 0f;

        while (digitalGlitchKino.intensity < targetValue)
        {
            t += Time.deltaTime * glitchSpeed;
            digitalGlitchKino.intensity = Mathf.Lerp(startValue, targetValue, t);
            yield return null;
        }

        digitalGlitchKino.intensity = targetValue; // Asegura valor final exacto
    }
}
