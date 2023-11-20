using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    public LevelOrders levelOrders;

    public List<Order> currentOrders = new List<Order>();

    private int currentOrder = 0;

    public UnityEvent<Order> newOrderArrive = new UnityEvent<Order>();

    private void Awake()
    {
        InitializeOrders();
    }

    private void Start()
    {
        StartCoroutine(AddNextOrder());
    }

    private void InitializeOrders()
    {
        var order = levelOrders.orderLists[currentOrder % levelOrders.orderLists.Count];

        order.processOrder = StartCoroutine(order.ProcessOrder());
        
        currentOrders.Add(order);
        
        newOrderArrive?.Invoke(order);

        currentOrder++;
    }

    public void FinishOrder()
    {
        var order = levelOrders.orderLists[0];
        
        StopCoroutine(order.processOrder);
        order.onOrderDelivered?.Invoke();
        
        currentOrders.Remove(order);
    }
    
    public Order GetFirstOrder()
    {
        return currentOrders.Count <= 0 ? null : currentOrders[0];
    }

    private IEnumerator AddNextOrder()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(levelOrders.minTimeToNextOrder, levelOrders.maxTimeToNextOrder));
            
            //var nextOrder = levelOrders.orderLists[currentOrder % levelOrders.orderLists.Count];

            InitializeOrders();
        }
    }
}

[Serializable]
public class Order
{
    public List<CropData> cropOrders = new List<CropData>();
    public float orderTime;
    
    public Action onOrderDelivered = delegate {  };
    public Action onOrderExpired = delegate {  };

    private WaitForSeconds _oneSecondDelay = new WaitForSeconds(1);

    public Coroutine processOrder;

    public IEnumerator ProcessOrder()
    {
        var orderTime = this.orderTime;
        
        while (orderTime > 0)
        {
            yield return _oneSecondDelay;

            orderTime -= 1;
        }
        
        onOrderExpired?.Invoke();
    }
}

[Serializable]
public class CropData
{
    public Crops crop;
    public int amount;
}
