using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct CharacterHeldData
{
    public BaseItem currentHeldItem;
    
    public UnityEvent OnRemoveItem;
}

public class CharacterHeldComponent : MonoBehaviour
{
    [SerializeField] private CharacterHeldData characterHeldData;
    [SerializeField] private UnityEvent<CharacterHeldData> OnHeldItem = new UnityEvent<CharacterHeldData>();

    [SerializeField] private UnityEvent<CharacterHeldData> OnUseItem = new UnityEvent<CharacterHeldData>();
    
    public bool ChangeHeldItem(BaseItem newItem, UnityEvent onRemoveItem)
    {
        if (characterHeldData.currentHeldItem != null)
        {
            RemoveHeldItem();
        }

        characterHeldData = new CharacterHeldData { currentHeldItem = newItem, OnRemoveItem = onRemoveItem };
        OnHeldItem?.Invoke(characterHeldData);

        return true;
    }

    public void RemoveHeldItem()
    {
        characterHeldData.OnRemoveItem?.Invoke();
        characterHeldData = new CharacterHeldData { currentHeldItem = null, OnRemoveItem = null };
        
        OnHeldItem?.Invoke(characterHeldData);
        
        //ChangeHeldItem(null, null);
    }

    public CharacterHeldData GetHeldData()
    {
        return characterHeldData;
    }

    public void UseHeldItem()
    {
        OnUseItem?.Invoke(characterHeldData);
    }
}
