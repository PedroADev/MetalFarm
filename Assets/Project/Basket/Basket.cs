using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Basket", fileName = "New Basket")]
public class Basket : BaseItem
{
    public List<BaseItem> crops = new List<BaseItem>();
}
