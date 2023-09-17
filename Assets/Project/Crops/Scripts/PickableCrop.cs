using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCrop : PickableObject<Crops>
{
    public override void PickItem(Interactor interactor)
    {
        interactor.characterHeldComponent.ChangeHeldItem(pickableObject);
            
        gameObject.SetActive(false);
    }
}
