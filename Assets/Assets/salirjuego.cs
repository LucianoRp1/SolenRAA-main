using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Si estás en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estás en una build (APK, PC, etc.)
        Application.Quit();
#endif
    }
}
