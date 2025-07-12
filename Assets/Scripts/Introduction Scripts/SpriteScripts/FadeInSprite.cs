using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInSprite : MonoBehaviour
{
    public float fadeSpeed = 2f; // velocidad de cambio
    public Image image;
    private Color currentColor;

    void Start()
    {
        if (image == null)
            image = GetComponent<Image>();

        currentColor = image.color;
    }

    void Update()
    {
        // Oscila entre 0.5 y 1
        float alpha = 0.55f + (Mathf.Sin(Time.time * fadeSpeed) * 0.5f);
        currentColor.a = alpha;
        image.color = currentColor;
    }
}
