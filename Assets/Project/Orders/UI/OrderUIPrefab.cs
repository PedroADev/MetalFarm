using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIPrefab : MonoBehaviour
{
    [SerializeField] private CropOrderUI cropOrderUIPrefab;
    [SerializeField] private Slider timePassedSlider;

    [SerializeField] private RectTransform cropOrderUIContent;

    [SerializeField] private Gradient gradient;
    [SerializeField] private Image sliderFillImage;
    
    public void InitializeOrder(Order order)
    {
        foreach (var cropOrder in order.cropOrders)
        {
            var _cropOrder = Instantiate(cropOrderUIPrefab, cropOrderUIContent);
            _cropOrder.Initialize(cropOrder);
        }
        
        StartCoroutine(AnimateSlider(order.orderTime));
        
        
        order.onOrderDelivered += DestroySelf;
        order.onOrderExpired += DestroySelf;
    }
    
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    
    private IEnumerator AnimateSlider(float time)
    {
        float timeElapsed = 0;
        
        while (timeElapsed < time)
        {
            yield return null;

            timeElapsed += Time.deltaTime;

            var sliderValue = 1 - timeElapsed / time;

            timePassedSlider.value = sliderValue;

            sliderFillImage.color = gradient.Evaluate(sliderValue);
        }
    }
}
