using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public CharacterAnimations characterAnimations;
    public CharacterHeldComponent characterHeldComponent;
    private InteractableComponent interactableComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactableComponent)
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
        interactableComponent = other.GetComponent<InteractableComponent>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(interactableComponent == null) interactableComponent = other.GetComponent<InteractableComponent>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactableComponent = null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        interactableComponent = other.GetComponent<InteractableComponent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(interactableComponent == null) interactableComponent = other.GetComponent<InteractableComponent>();
    }

    private void OnTriggerExit(Collider other)
    {
        interactableComponent = null;
    }
}
