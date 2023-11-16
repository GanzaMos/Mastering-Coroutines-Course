using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum LoopType
{
    Repeat,
    PingPong
}

public class Driver : MonoBehaviour
{
    public Image myImage;
    public float duration;
    public int loopCount = 1;
    public LoopType loopType;
    public bool autoLoop;
    
    public UnityEvent startEvent;
    public UnityEvent endEvent;
    
    
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
        float wholeDuration = duration * loopCount;
        
        
        if (_playForward == true)
            elapsedTime = 0;
        else
            elapsedTime = wholeDuration;

        //in case if we coroutine was finished in the middle of the progress
        if (_inProgress == true)
            elapsedTime = _progress;
        //if we are not in Progress, play some start event
        else
            startEvent?.Invoke();
        
        while (0 <= elapsedTime && elapsedTime <= wholeDuration)
        {
            _inProgress = true;
            
            //increasing or decreasing value?
            if (_playForward == true)
                elapsedTime += Time.deltaTime;
            else
                elapsedTime -= Time.deltaTime;

            //cache the progress Coroutine
            _progress = elapsedTime;
            
            float rawResult = elapsedTime / duration;

            //at the and of the looping make the value more even
            if (wholeDuration - rawResult < 0.001)
                rawResult = loopCount;
            
            //now it's time to loop this thing
            float result = 0;
            if (loopType == LoopType.Repeat)
                result = Mathf.Repeat(rawResult, 1.0001f); 
            else if (loopType == LoopType.PingPong)
                result = Mathf.PingPong(rawResult, 0.99999f);
            
            myImage.fillAmount = result;

            yield return null;
        }
        
        if (autoLoop == true)
            Run(_playForward);
        
        _inProgress = false;
        endEvent?.Invoke();
    }
}
