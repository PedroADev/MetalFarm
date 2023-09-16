using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Tool", fileName = "New Tool")]
public class Tools : ScriptableObject
{
    public string toolName;
    public bool isHolding;
    public Sprite toolSprite;
}
