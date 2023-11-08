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
    [SerializeField] private SpriteRenderer holdableHolderSpriteRenderer;

    public bool ChangeHeldItem(BaseItem newItem, UnityEvent onRemoveItem)
    {
        if (characterHeldData.currentHeldItem != null)
        {
            RemoveHeldItem();
        }

        characterHeldData = new CharacterHeldData { currentHeldItem = newItem, OnRemoveItem = onRemoveItem };
        holdableHolderSpriteRenderer.sprite = newItem.sprite;

        return true;
    }

    public void RemoveHeldItem()
    {
        characterHeldData.OnRemoveItem?.Invoke();
        characterHeldData = new CharacterHeldData { currentHeldItem = null, OnRemoveItem = null };

        holdableHolderSpriteRenderer.sprite = null;
        //ChangeHeldItem(null, null);
    }

    public CharacterHeldData GetHeldData()
    {
        return characterHeldData;
    }
}
