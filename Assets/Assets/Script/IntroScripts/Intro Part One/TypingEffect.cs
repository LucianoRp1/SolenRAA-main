using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public float velocidad = 0.05f; // Velocidad por letra

    private TextMeshProUGUI tmp;
    private string textoOriginal;
    private string textoMostrado = "";
    private float timer;
    private int indiceActual;
    private bool dentroDeEtiqueta;

    public bool textEnd=false;


    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        textoOriginal = tmp.text; // Guarda el texto original con etiquetas
        tmp.text = ""; // Empieza vacío
    }

    void Update()
    {
        if (indiceActual < textoOriginal.Length)
        {
            timer += Time.deltaTime;

            if (timer >= velocidad)
            {
                // Si es inicio de etiqueta, copiarla entera de golpe
                if (textoOriginal[indiceActual] == '<')
                {
                    dentroDeEtiqueta = true;
                }

                textoMostrado += textoOriginal[indiceActual];
                indiceActual++;

                // Si es fin de etiqueta, salir del modo etiqueta
                if (dentroDeEtiqueta && textoOriginal[indiceActual - 1] == '>')
                {
                    dentroDeEtiqueta = false;
                }

                // Solo reiniciamos el tiempo cuando no estamos dentro de una etiqueta
                if (!dentroDeEtiqueta)
                {
                    timer = 0f;
                }
                else
                {
                    // Si seguimos dentro de la etiqueta, no esperamos, copiamos hasta cerrarla
                    while (indiceActual < textoOriginal.Length && textoOriginal[indiceActual] != '>')
                    {
                        textoMostrado += textoOriginal[indiceActual];
                        indiceActual++;
                    }
                    // Copiar el '>' y salir
                    if (indiceActual < textoOriginal.Length)
                    {
                        textoMostrado += textoOriginal[indiceActual];
                        indiceActual++;
                    }
                    dentroDeEtiqueta = false;
                    timer = 0f; // Reset después de cerrar etiqueta
                }
            }

            tmp.text = textoMostrado;
        }
        else if (!textEnd) //  Solo entra una vez
        {
            textEnd = true;
            
        }
    }
}
