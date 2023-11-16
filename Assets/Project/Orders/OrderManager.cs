using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public LevelOrders levelOrders;
}

[Serializable]
public class Order
{
    public List<CropOrder> cropOrders = new List<CropOrder>();
    public float orderTime;
}

[Serializable]
public class CropOrder
{
    public Crops crop;
    public int amount;
}
