using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeldComponent : MonoBehaviour
{
    [field:SerializeField] public BaseItem CurrentHeldItem { get; private set; }

    public bool ChangeHeldItem(BaseItem newItem)
    {
        CurrentHeldItem = newItem;

        return true;
    }

    public void RemoveHeldItem()
    {
        ChangeHeldItem(null);
    }
}
