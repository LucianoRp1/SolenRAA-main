using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public TextMeshProUGUI tmpText;

    private Color currentColor;

    void Start()
    {
        if (tmpText != null)
            currentColor = tmpText.color;
    }

    void Update()
    {
        if (tmpText == null) return;

        float alpha = 0.55f + (Mathf.Sin(Time.time * fadeSpeed) * 0.5f);
        alpha = Mathf.Clamp01(alpha);

        currentColor.a = alpha;
        tmpText.color = currentColor;
    }
}
