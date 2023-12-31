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

    public void InitializeItemList(List<BaseItem> itemsList)
    {
        expectedBaseItems = itemsList;
    }
    
    public override bool Interact(Interactor interactor)
    {
        if(!CanInteract) return false;
        
        var heldItem = interactor.characterHeldComponent.GetHeldData();

        if (!CheckHeldItem(heldItem)) return false;
        
        OnInteractionSuccess?.Invoke(interactor);
        OnItemInteractionSuccess?.Invoke(heldItem.currentHeldItem);

        return true;
    }

    public void RemoveItem(Interactor interactor)
    {
        if (CheckHeldItem(interactor.characterHeldComponent.GetHeldData()))
        {
            interactor.characterHeldComponent.RemoveHeldItem();
        }
    }

    private bool CheckHeldItem(CharacterHeldData heldData)
    {
        return expectedBaseItems.Contains(heldData.currentHeldItem) || expectedBaseItems.Count <= 0;
    }

    public void ChangeCanInteract(bool value)
    {
        CanInteract = value;
    }
}
