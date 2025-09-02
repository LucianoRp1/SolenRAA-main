using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public Image targetImage;

    private Color currentColor;

    void Start()
    {
        if (targetImage != null)
            currentColor = targetImage.color;
    }

    void Update()
    {
        if (targetImage == null) return;

        float alpha = 0.55f + (Mathf.Sin(Time.time * fadeSpeed) * 0.5f);
        alpha = Mathf.Clamp01(alpha);

        currentColor.a = alpha;
        targetImage.color = currentColor;
    }
}
