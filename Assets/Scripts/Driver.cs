using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    public Image myImage;
    public float duration;
    bool _playForward;
    IEnumerator _routine;

    bool _inProgress;
    float _progress;

    public void RunForward()
    {
        Run(true);
    }

    public void RunBackward()
    {
        Run(false);
    }

    public void Run(bool forward)
    {
        _playForward = forward;
        Stop();
        _routine = DriverRoutine();
        StartCoroutine(_routine);
    }

    public void Stop()
    {
        if (_routine != null) 
            StopCoroutine(_routine);
    }

    IEnumerator DriverRoutine()
    {
        float elapsedTime;
        
        if (_playForward == true)
            elapsedTime = 0;
        else
            elapsedTime = duration;

        if (_inProgress == true)
            elapsedTime = _progress;
        
        while (0 <= elapsedTime && elapsedTime <= duration)
        {
            _inProgress = true;
            
            if (_playForward == true)
                elapsedTime += Time.deltaTime;
            else
                elapsedTime -= Time.deltaTime;

            _progress = elapsedTime;
            
            float result = elapsedTime / duration;

            myImage.fillAmount = result;

            yield return null;
        }

        _inProgress = false;
    }
}
