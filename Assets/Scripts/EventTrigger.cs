using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEvent = new UnityEvent();

    public void TriggerEvent()
    {
        onTriggerEvent?.Invoke();
    }
}
