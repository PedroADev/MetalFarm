using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    [SerializeField] private Crops cropAsset;

    [SerializeField] private Animator animator;
    public Crops GetCrop() => cropAsset;

    public event Action CropReady = delegate {  };
    public event Action CropHarvested = delegate {  };

    public void ChangeState(GrowingStateInfo newState)
    {
        
    }

    [ContextMenu("Crop Ready")]
    public void OnCropReady()
    {
        animator.SetTrigger("Ready");
        CropReady();
    }
    
    public void OnCropHarvested()
    {
        CropHarvested();
    }
}
