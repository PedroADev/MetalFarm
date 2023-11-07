using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableComponent : MonoBehaviour
{
    public UnityEvent OnDestroyed;

    public void DestroyComponent()
    {
        OnDestroyed?.Invoke();
        
        Destroy(gameObject, 0.1f);
    }
}
