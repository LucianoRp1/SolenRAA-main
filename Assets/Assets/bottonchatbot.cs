using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAChatBot : MonoBehaviour
{
    public void CargarEscenaChatBot()
    {
        SceneManager.LoadScene("TextBot");
    }
}
