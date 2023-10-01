using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool CanInteract { get; protected set; } = true;
    
    public UnityEvent<Interactor> OnInteractionSuccess = new UnityEvent<Interactor>();
    
    public virtual bool Interact(Interactor interactor)
    {
        if (CanInteract)
        {
            OnInteractionSuccess?.Invoke(interactor);

            return true;
        }

        return false;
    }
}

public interface IInteractable
{
    bool Interact(Interactor interactor);
}
