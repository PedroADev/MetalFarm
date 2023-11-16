using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Orders", fileName = "Orders")]
public class LevelOrders : ScriptableObject
{
    public List<Order> orderLists = new List<Order>();
}
