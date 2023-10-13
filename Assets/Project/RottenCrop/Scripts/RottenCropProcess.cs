using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RottenCropProcess : MonoBehaviour
{
    [SerializeField] private PickableCrop pickableCrop;
    private Crops crop;

    private Coroutine c_rottenProcess;

    public UnityEvent onFinishRotten;

    private void OnEnable()
    {
        crop = pickableCrop.GetPickableObject();
        
        StartRotten();
    }

    private void OnDisable()
    {
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
        yield return new WaitForSeconds(crop.rottenCropData.timeToRotten);

        Instantiate(crop.rottenCropData.rottenCrop, transform.position, Quaternion.identity);
        onFinishRotten?.Invoke();
    }
}
