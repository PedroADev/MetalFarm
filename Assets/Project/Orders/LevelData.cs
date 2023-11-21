using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Orders", fileName = "Orders")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<Order> orderLists = new List<Order>();
    
    public LevelScore[] levelScore = new LevelScore[3];

    public int maxOrders = 5;
    
    public float minTimeToNextOrder;
    public float maxTimeToNextOrder;

    public float timeToCompleteLevel;

    public Order GetOrder(int index)
    {
        var order = orderLists[index % orderLists.Count];

        return new Order
        {
            orderTime = order.orderTime,
            cropOrders = order.cropOrders,
            
            onOrderExpired = null,
            onOrderDelivered = null,
            
            processOrder = null
        };
    }
}

[Serializable]
public struct LevelScore
{
    public Score score;
}
