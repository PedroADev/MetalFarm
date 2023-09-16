using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ItemInteractionBehaviour : InteractableComponent
{
    [SerializeReference] public List<BaseItem> expectedBaseItems;
    public UnityEvent<BaseItem> OnItemInteractionSuccess = new UnityEvent<BaseItem>();

    public override void Interact(Interactor interactor)
    {
        var heldItem = interactor.characterHeldComponent.CurrentHeldItem;
        
        if (CheckHeldItem(heldItem))
        {
            OnInteractionSuccess?.Invoke(interactor);
            OnItemInteractionSuccess?.Invoke(heldItem);
        }
    }

    public void RemoveItem(Interactor interactor)
    {
        if (CheckHeldItem(interactor.characterHeldComponent.CurrentHeldItem))
        {
            interactor.characterHeldComponent.RemoveHeldItem();
        }
    }

    private bool CheckHeldItem(BaseItem heldItem)
    {
        return expectedBaseItems.Contains(heldItem);
    }
}
