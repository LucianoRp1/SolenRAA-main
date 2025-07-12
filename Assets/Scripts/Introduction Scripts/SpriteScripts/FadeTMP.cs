using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeTMP : MonoBehaviour
{
    public float fadeSpeed = 2f; // velocidad de cambio
    public TextMeshProUGUI tmpText;
    private Color currentColor;

    void Start()
    {
        if (tmpText == null)
            tmpText = GetComponent<TextMeshProUGUI>();

        currentColor = tmpText.color;
    }

    void Update()
    {
        // Oscila entre 0.5 y 1
        float alpha = 0.55f + (Mathf.Sin(Time.time * fadeSpeed) * 0.5f);
        alpha = Mathf.Clamp01(alpha); // asegurarse que quede entre 0 y 1

        currentColor.a = alpha;
        tmpText.color = currentColor;
    }
}
