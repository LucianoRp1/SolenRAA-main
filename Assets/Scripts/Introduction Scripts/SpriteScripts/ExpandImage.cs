using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandImage : MonoBehaviour
{
    public RectTransform panelHijo;
    public RectTransform panelPadre;
    public float velocidad = 500f; // velocidad en píxeles por segundo
    public float margen = 50f; // margen en píxeles

    private Vector2 tamañoObjetivo;
    private bool isExpanding = false;

    void Start()
    {
        if (panelHijo == null || panelPadre == null)
        {
            Debug.LogError("Asigna el panel hijo y el panel padre en el Inspector");
            return;
        }

        // Configura anchors en Stretch-Stretch para ocupar todo el padre
        panelHijo.anchorMin = new Vector2(0f, 0f);
        panelHijo.anchorMax = new Vector2(1f, 1f);
        panelHijo.pivot = new Vector2(0.5f, 0.5f);

        // Comienza con tamaño cero (offsets máximos)
        panelHijo.offsetMin = panelPadre.rect.size / 2f;
        panelHijo.offsetMax = -panelPadre.rect.size / 2f;

        // Calcula el tamaño objetivo considerando el margen
        tamañoObjetivo = new Vector2(margen, margen);

        isExpanding = true;
    }

    void Update()
    {
        if (isExpanding)
        {
            // Reduce offsetMin y offsetMax gradualmente hasta llegar al margen deseado
            panelHijo.offsetMin = Vector2.MoveTowards(panelHijo.offsetMin, new Vector2(margen, margen), velocidad * Time.deltaTime);
            panelHijo.offsetMax = Vector2.MoveTowards(panelHijo.offsetMax, new Vector2(-margen, -margen), velocidad * Time.deltaTime);

            // Si llegó al margen final, detiene la expansión
            if (panelHijo.offsetMin == new Vector2(margen, margen) && panelHijo.offsetMax == new Vector2(-margen, -margen))
            {
                isExpanding = false;
            }
        }
    }
}
