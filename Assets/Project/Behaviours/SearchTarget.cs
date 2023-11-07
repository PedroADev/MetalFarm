using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SearchTarget : MonoBehaviour
{
    public List<TargetType> targetTypePriority;
    
    public UnityEvent<Targetable> onTargetFound;

    private void OnEnable()
    {
        Search();
    }

    private void Search()
    {
        var targets = FindObjectsOfType<Targetable>();

        foreach (var target in targets)
        {
            if(target.gameObject == gameObject) continue;
            
            if (targetTypePriority.All(t => target.targetType != t)) continue;
            onTargetFound?.Invoke(target);
                    
            return;
        }
    }
}
