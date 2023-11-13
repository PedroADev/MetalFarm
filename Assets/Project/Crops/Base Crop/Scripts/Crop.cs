using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    [SerializeField] private Crops cropAsset;

    [SerializeField] private Animator animator;
    [SerializeField] private InteractableComponent interactableComponent;
    public Crops GetCrop() => cropAsset;

    public event Action CropReady = delegate {  };
    public event Action CropHarvested = delegate {  };

    public void ChangeState(GrowingStateInfo newState)
    {
        animator.SetTrigger("Ready");
    }

    [ContextMenu("Crop Ready")]
    public void OnCropReady()
    {
        interactableComponent.gameObject.SetActive(true);
        animator.SetTrigger("Ready");
        CropReady();
    }
    
    public void OnCropHarvested()
    {
        CropHarvested();
    }
}
