using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public CharacterAnimations characterAnimations;
    public CharacterHeldComponent characterHeldComponent;
    
    private InteractableComponent[] interactableComponents;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var interactableComponent in interactableComponents)
            {
                interactableComponent.Interact(this);

                /*if (characterHeldComponent.ChangeHeldItem(receivedItem))
                {
                    //DO something
                }*/
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactableComponents = other.GetComponents<InteractableComponent>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(interactableComponents is not { Length: > 0 }) interactableComponents = other.GetComponents<InteractableComponent>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactableComponents = null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        interactableComponents = other.GetComponents<InteractableComponent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(interactableComponents is not { Length: > 0 }) interactableComponents = other.GetComponents<InteractableComponent>();
    }

    private void OnTriggerExit(Collider other)
    {
        interactableComponents = null;
    }
}
