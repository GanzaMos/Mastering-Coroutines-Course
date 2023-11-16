using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float duration;
    IEnumerator _routine;
    
    public void Run()
    {
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
        float elapsedTime = 0;
        
        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;

            float result = elapsedTime / duration;
            
            Debug.Log("Result: " + result);

            yield return null;
        }
    }
}
