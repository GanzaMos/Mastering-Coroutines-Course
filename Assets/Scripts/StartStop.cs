using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour
{
    public Image image;

    IEnumerator _myRoutine;

    public void Run()
    {
        Stop();
        _myRoutine = ChangeFill();
        StartCoroutine(_myRoutine);
    }
    
    public void Stop()
    {
        if (_myRoutine != null)
        {
            StopCoroutine(_myRoutine);
        }
    }

    IEnumerator ChangeFill()
    {
        float elapsedTime = 0;

        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            image.fillAmount = elapsedTime;
            yield return null;
        }
    }
}
