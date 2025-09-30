using UnityEngine;

public class SunController : MonoBehaviour
{
    [Range(0f, 24f)]
    public float hora = 12f; // Hora del día (12 = mediodía)

    void Update()
    {
        // 15 grados por cada hora desde las 6 AM
        float angulo = (hora - 6f) * 15f;

        // Rotar el Sol (Directional Light) en X
        transform.rotation = Quaternion.Euler(angulo, 0f, 0f);
    }
}
