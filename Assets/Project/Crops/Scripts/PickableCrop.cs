using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCrop : PickableObject<Crops>
{
    public override void InitializePickableObject(Crops baseItem)
    {
        base.InitializePickableObject(baseItem);

        spriteRenderer.sprite = baseItem.cropSprite;
    }

    public override void PickItem(Interactor interactor)
    {
        base.PickItem(interactor);
        
        
    }
}
