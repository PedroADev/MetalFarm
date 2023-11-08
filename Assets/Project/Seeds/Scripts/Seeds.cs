using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseItem: ScriptableObject
{
    public Sprite sprite;
}

[CreateAssetMenu(menuName = "Seed", fileName = "New Seed")]
public class Seeds : BaseItem
{
    public Crops cropToGrow;
}