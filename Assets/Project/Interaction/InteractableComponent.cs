using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractable
{
    public virtual void Interact(Interactor interactor)
    {
        OnInteractionSuccess?.Invoke(interactor);
    }

    public UnityEvent<Interactor> OnInteractionSuccess = new UnityEvent<Interactor>();
}

public interface IInteractable
{
    void Interact(Interactor interactor);
}
