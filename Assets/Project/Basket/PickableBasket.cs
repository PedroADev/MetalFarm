using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickableBasket : PickableObject<BaseItem>
{
    public List<CropData> crops = new List<CropData>();
    
    private void Awake()
    {
        InitializeBasket();
    }

    public void InitializeBasket()
    {
        pickableObject = ScriptableObject.CreateInstance<Basket>();
        ((Basket)pickableObject).pickableBasket = this;

        crops = new List<CropData>();
    }

    public void AddItem(BaseItem item)
    {
        AddItem((Crops)item);
    }
    
    private void AddItem(Crops crop)
    {
        var cropData = crops.FirstOrDefault(c => c.crop == crop);

        if (cropData != null)
        {
            cropData.amount++;
            
            return;
        }
        
        crops.Add(new CropData { crop = crop, amount = 1 });
    }
}
