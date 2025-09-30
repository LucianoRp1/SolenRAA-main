using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefIntro : MonoBehaviour
{
    public void DeletePlayerPref()
    {
        PlayerPrefs.DeleteKey("IntroEnded");
        PlayerPrefs.Save();
    }
}
