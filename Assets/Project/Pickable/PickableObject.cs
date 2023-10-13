using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PickableObject<T> : MonoBehaviour where T : BaseItem
{
    [SerializeField] protected T pickableObject;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    [SerializeField] protected UnityEvent<T> OnPickItem = new UnityEvent<T>();
    [SerializeField] protected UnityEvent OnRemoveItem = new UnityEvent();

    public virtual void InitializePickableObject(T baseItem)
    {
        pickableObject = baseItem;
    }

    public virtual void PickItem(Interactor interactor)
    {
        if (interactor.characterHeldComponent.GetHeldData().currentHeldItem == null)
        {
            interactor.characterHeldComponent.ChangeHeldItem(pickableObject, OnRemoveItem);
            
            OnPickItem?.Invoke(pickableObject);
            //Destroy(gameObject);
        }
    }

    public T GetPickableObject() => pickableObject;
}
