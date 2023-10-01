using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableTool : PickableObject<Tools>
{
    [SerializeField] private GameObject readyToPickState;
    [SerializeField] private GameObject unreadyToPickState;

    private void OnEnable()
    {
        OnRemoveItem.AddListener(ShowTool);
    }

    private void OnDisable()
    {
        OnRemoveItem.RemoveListener(ShowTool);
    }

    public override void InitializePickableObject(Tools baseItem)
    {
        base.InitializePickableObject(baseItem);
        
        spriteRenderer.sprite = baseItem.toolSprite;
    }

    public void HideTool()
    {
        readyToPickState.SetActive(false);
        unreadyToPickState.SetActive(true);
    }

    public void ShowTool()
    {
        readyToPickState.SetActive(true);
        unreadyToPickState.SetActive(false);
    }
}
