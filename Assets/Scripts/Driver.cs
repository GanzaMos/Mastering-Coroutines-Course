using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float duration;
    bool _playForward;
    IEnumerator _routine;

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
        
        while (0 <= elapsedTime && elapsedTime <= duration)
        {
            if (_playForward == true)
                elapsedTime += Time.deltaTime;
            else
                elapsedTime -= Time.deltaTime;

            float result = elapsedTime / duration;
            
            Debug.Log("Result: " + result);

            yield return null;
        }
    }
}
