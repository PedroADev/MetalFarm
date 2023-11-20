using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private OrderUIPrefab orderUIPrefab;
    [SerializeField] private RectTransform content;

    public void AddNewOrder(Order order)
    {
        var _orderPanel = Instantiate(orderUIPrefab, content);

        _orderPanel.InitializeOrder(order);
    }
}
