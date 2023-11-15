using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarFade : MonoBehaviour
{
    public Image image;

    void ChangeAlpha()
    {
        Color newImageColor = image.color;

        for (float i = 1; i >= 0; i -= 0.2f)
        {
            newImageColor.a = i;
            image.color = newImageColor;
        }
    }

    void Start()
    {
        //ChangeAlpha();
        StartCoroutine(ChangeAlphaRoutine());
    }

    // void Update()
    // {
    //     Color newImageColor = image.color;
    //
    //     if (newImageColor.a >= 0)
    //     {
    //         newImageColor.a -= 0.2f;
    //         image.color = newImageColor;
    //     }
    // }

    IEnumerator ChangeAlphaRoutine()
    {
        yield return new WaitForEndOfFrame();
        
        Color newImageColor = image.color;

        for (float i = 1; i >= 0; i -= 0.2f)
        {
            newImageColor.a = i;
            image.color = newImageColor;
            yield return null;
        }
    }
}
