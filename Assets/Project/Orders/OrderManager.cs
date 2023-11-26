using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    public LevelData levelData;

    public List<Order> currentOrders = new List<Order>();

    private int currentOrder = 0;

    public UnityEvent<Order> newOrderArrive = new UnityEvent<Order>();
    public static event Action<Order> OnOrderDelivered = delegate(Order order) {  };

    //Comment
    public void Initialize()
    {
        InitializeOrders();
        
        StartCoroutine(AddNextOrder());
    }

    private void InitializeOrders()
    {
        var order = levelData.GetOrder(currentOrder);

        order.processOrder = StartCoroutine(order.ProcessOrder());

        order.onOrderExpired += FinishOrder;
        
        currentOrders.Add(order);
        
        newOrderArrive?.Invoke(order);

        OnOrderDelivered?.Invoke(order);
        
        currentOrder++;
    }

    public void CompleteOrder()
    {
        FinishOrder();
    }

    private void FinishOrder()
    {
        var order = currentOrders[0];

        order.onOrderExpired -= FinishOrder;
        
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
            yield return new WaitForSeconds(Random.Range(levelData.minTimeToNextOrder, levelData.maxTimeToNextOrder));

            if (currentOrders.Count < levelData.maxOrders)
            {
                InitializeOrders();
            }
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

    public float orderScore;

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
