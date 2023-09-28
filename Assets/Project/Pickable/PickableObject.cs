using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PickableObject<T> : MonoBehaviour where T : BaseItem
{
    [SerializeField] protected T pickableObject;

    [SerializeField] private UnityEvent<T> OnPickItem = new UnityEvent<T>();

    public virtual void InitializePickableObject(T baseItem)
    {
        pickableObject = baseItem;
    }

    public virtual void PickItem(Interactor interactor)
    {
        if (interactor.characterHeldComponent.CurrentHeldItem == null)
        {
            interactor.characterHeldComponent.ChangeHeldItem(pickableObject);
            
            OnPickItem?.Invoke(pickableObject);
            //Destroy(gameObject);
        }
    }
}
