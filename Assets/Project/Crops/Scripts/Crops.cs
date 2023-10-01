using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "")]
public class Crops : BaseItem
{
    public Sprite cropSprite;
    public List<Tools> usableTools = new List<Tools>();
}
