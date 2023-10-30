using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RottenCropProcess : MonoBehaviour
{
    [SerializeField] private Crop crop;

    private Coroutine c_rottenProcess;

    public UnityEvent onFinishRotten;

    private void OnEnable()
    {
        crop.CropReady += StartRotten;
    }

    private void OnDisable()
    {
        crop.CropReady -= StartRotten;
        
        StopRotten();
    }

    private void StartRotten()
    {
        c_rottenProcess ??= StartCoroutine(RottenProcess());
    }

    private void StopRotten()
    {
        if(c_rottenProcess != null) StopCoroutine(c_rottenProcess);
    }
    
    private IEnumerator RottenProcess()
    {
        yield return new WaitForSeconds(crop.GetCrop().rottenCropData.timeToRotten);

        onFinishRotten?.Invoke();
    }
}
