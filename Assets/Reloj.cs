using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RelojCuentaRegresiva : MonoBehaviour
{
    public Image relojImagen;           // El Image circular
    public TextMeshProUGUI tiempoTexto; // El texto en el centro

    private float tiempoTotal = 3600f;  // 1 hora en segundos
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        ActualizarReloj();
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante < 0) tiempoRestante = 0;
            ActualizarReloj();
        }
    }

    void ActualizarReloj()
    {
        // Actualizar la barra circular
        relojImagen.fillAmount = tiempoRestante / tiempoTotal;

        // Actualizar el texto central
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        tiempoTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Cambiar a rojo si queda menos de 10 minutos
        if (tiempoRestante <= 600)
        {
            relojImagen.color = Color.red;
        }
        else
        {
            relojImagen.color = new Color(0.5f, 0.5f, 0.5f); // gris #7F7F7F
        }
    }
}
