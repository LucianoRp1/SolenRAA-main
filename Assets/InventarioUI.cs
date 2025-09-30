using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    [Header("Grupo 1")]
    public Image[] insigniasGrupo1;
    public TMP_Text textoGrupo1;

    [Header("Grupo 2")]
    public Image[] insigniasGrupo2;
    public TMP_Text textoGrupo2;

    [Header("Grupo 3")]
    public Image[] insigniasGrupo3;
    public TMP_Text textoGrupo3;

    [Header("Contador Global")]
    public TMP_Text textoTotalInsignias;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnInsigniasActualizadas += ActualizarUI;
            ActualizarUI(); // Refrescar al activarse
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnInsigniasActualizadas -= ActualizarUI;
        }
    }

    public void ActualizarUI()
    {
        // Grupo 1
        for (int i = 0; i < insigniasGrupo1.Length; i++)
            insigniasGrupo1[i].enabled = GameManager.Instance.grupo1[i];
        textoGrupo1.text = GameManager.Instance.ProgresoGrupo1 + "/3";

        // Grupo 2
        for (int i = 0; i < insigniasGrupo2.Length; i++)
            insigniasGrupo2[i].enabled = GameManager.Instance.grupo2[i];
        textoGrupo2.text = GameManager.Instance.ProgresoGrupo2 + "/3";

        // Grupo 3
        for (int i = 0; i < insigniasGrupo3.Length; i++)
            insigniasGrupo3[i].enabled = GameManager.Instance.grupo3[i];
        textoGrupo3.text = GameManager.Instance.ProgresoGrupo3 + "/3";

        // Contador Global
        textoTotalInsignias.text = $"Completaste {GameManager.Instance.totalInsigniasGanadas} Trabajos Auxiliares";
    }
}
