using UnityEngine;

public class Pregunta : MonoBehaviour
{
    public int grupo;         // 1, 2 o 3
    public int indexInsignia; // 0, 1 o 2

    public void ResponderCorrecto()
    {
        GameManager.Instance.AsignarInsignia(grupo, indexInsignia);
        // 👇 Ya no cambiamos de escena, solo actualizamos
        // La UI se refresca automáticamente gracias al evento
    }
}
