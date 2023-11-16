using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBasket : PickableObject<BaseItem>
{
    private void Awake()
    {
        pickableObject = ScriptableObject.CreateInstance<Basket>();
    }

    public void AddItem(BaseItem item)
    {
        ((Basket)pickableObject).crops.Add(item);
    }
}
