using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRollo : MonoBehaviour
{
    // Esta función se puede llamar desde un botón o cualquier otro evento
    public void LoadRolloScene()
    {
        SceneManager.LoadScene("Rollo");
    }
}
