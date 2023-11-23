using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryStation : MonoBehaviour
{
    [SerializeField] private OrderManager orderManager;
    
    public void OnCharacterInteract(Interactor interactor)
    {
        var heldItem = interactor.characterHeldComponent.GetHeldData().currentHeldItem as Basket;
        if(heldItem == null) return;

        var orderData = orderManager.GetFirstOrder();
        
        if(orderData == null) return;

        foreach (var order in orderData.cropOrders)
        {
            var crops = heldItem.pickableBasket.crops.FirstOrDefault(c => c.crop == order.crop);
            
            if(crops == null || crops.amount != order.amount) return;
        }
        
        heldItem.pickableBasket.InitializeBasket();

        Debug.Log("entrega feita");
        interactor.characterHeldComponent.RemoveHeldItem();
        orderManager.CompleteOrder();
    }
}
