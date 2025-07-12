using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibratePhoneAlert : MonoBehaviour
{
    private Coroutine vibracionCoroutine;

    void Update()
    {
        if (vibracionCoroutine == null)
        {
            vibracionCoroutine = StartCoroutine(VibrarMientrasAlerta());
        }
    }

    IEnumerator VibrarMientrasAlerta()
    {
        while (true)
        {
            Handheld.Vibrate();
            yield return new WaitForSeconds(1f);
        }
    }
}
