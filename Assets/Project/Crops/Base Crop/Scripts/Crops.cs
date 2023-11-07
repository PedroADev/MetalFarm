using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "")]
public class Crops : BaseItem
{
    public Crop cropPrefab;
    public List<Tools> usableTools = new List<Tools>();

    public GrowingStateInfo[] growingStateInfos;
    public RottenCropData rottenCropData = new RottenCropData();
}

[Serializable]
public class RottenCropData
{
    public float timeToRotten = 5f;
}