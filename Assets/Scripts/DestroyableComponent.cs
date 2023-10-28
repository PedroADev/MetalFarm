using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableComponent : MonoBehaviour
{
    public UnityEvent OnDestroyed;

    private void OnEnable()
    {
        OnDestroyed.AddListener(DestroyComponent);
    }

    private void OnDisable()
    {
        OnDestroyed.RemoveListener(DestroyComponent);
    }

    private void DestroyComponent()
    {
        Debug.Log("Destruiu");
        Destroy(gameObject);
    }
}
