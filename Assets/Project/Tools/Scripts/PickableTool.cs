using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableTool : PickableObject<Tools>
{
    [SerializeField] private GameObject readyToPickState;
    [SerializeField] private GameObject unreadyToPickState;
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
