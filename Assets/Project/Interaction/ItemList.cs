using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemList<T> : MonoBehaviour where T : BaseItem
{
    [SerializeField] protected List<T> itemsList = new List<T>();

    public bool Contains(T item)
    {
        return itemsList.Contains(item);
    }
}
