using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Insignias por grupo (3 cada uno)
    public bool[] grupo1 = new bool[3];
    public bool[] grupo2 = new bool[3];
    public bool[] grupo3 = new bool[3];

    // Contador global
    public int totalInsigniasGanadas = 0;

    // Evento para actualizar la UI
    public event Action OnInsigniasActualizadas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CargarProgreso();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AsignarInsignia(int grupo, int index)
    {
        bool[] grupoActual = null;

        switch (grupo)
        {
            case 1: grupoActual = grupo1; break;
            case 2: grupoActual = grupo2; break;
            case 3: grupoActual = grupo3; break;
        }

        if (grupoActual != null && index >= 0 && index < grupoActual.Length)
        {
            if (!grupoActual[index]) // Solo si es nueva
            {
                grupoActual[index] = true;
                totalInsigniasGanadas++; // 👈 sumamos al total global

                Debug.Log($"✅ Insignia asignada: Grupo {grupo}, Índice {index}. Total: {totalInsigniasGanadas}");

                GuardarProgreso();
                OnInsigniasActualizadas?.Invoke();
            }
        }
    }

    // --- PROGRESOS POR GRUPO ---
    public int ProgresoGrupo1 => CalcularProgreso(grupo1);
    public int ProgresoGrupo2 => CalcularProgreso(grupo2);
    public int ProgresoGrupo3 => CalcularProgreso(grupo3);

    private int CalcularProgreso(bool[] grupo)
    {
        int count = 0;
        foreach (bool insignia in grupo)
            if (insignia) count++;
        return count;
    }

    // --- GUARDADO ---
    private void GuardarProgreso()
    {
        GuardarGrupo("Grupo1", grupo1);
        GuardarGrupo("Grupo2", grupo2);
        GuardarGrupo("Grupo3", grupo3);

        PlayerPrefs.SetInt("TotalInsigniasGanadas", totalInsigniasGanadas);

        PlayerPrefs.Save();
    }

    private void GuardarGrupo(string claveBase, bool[] grupo)
    {
        for (int i = 0; i < grupo.Length; i++)
            PlayerPrefs.SetInt($"{claveBase}_{i}", grupo[i] ? 1 : 0);
    }

    private void CargarProgreso()
    {
        CargarGrupo("Grupo1", grupo1);
        CargarGrupo("Grupo2", grupo2);
        CargarGrupo("Grupo3", grupo3);

        totalInsigniasGanadas = PlayerPrefs.GetInt("TotalInsigniasGanadas", 0);
    }

    private void CargarGrupo(string claveBase, bool[] grupo)
    {
        for (int i = 0; i < grupo.Length; i++)
        {
            grupo[i] = PlayerPrefs.GetInt($"{claveBase}_{i}", 0) == 1;
        }
    }
}
