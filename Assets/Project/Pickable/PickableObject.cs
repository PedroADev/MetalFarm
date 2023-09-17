using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableObject<T> : MonoBehaviour where T : BaseItem
{
    [SerializeField] protected T pickableObject;

    public virtual void InitializePickableObject(T baseItem)
    {
        pickableObject = baseItem;
    }

    public virtual void PickItem(Interactor interactor)
    {
        if (interactor.characterHeldComponent.CurrentHeldItem == null)
        {
            interactor.characterHeldComponent.ChangeHeldItem(pickableObject);
            
            Destroy(gameObject);
        }
    }
}
