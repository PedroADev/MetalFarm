using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropInteractionBehaviour : ItemInteractionBehaviour
{
    public override bool Interact(Interactor interactor)
    {
        if(base.Interact(interactor))
        {
            expectedBaseItems = new List<BaseItem>(((Crops)interactor.characterHeldComponent.GetHeldData().currentHeldItem).usableTools);
        }

        return true;
    }
}
