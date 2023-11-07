using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    public TargetType targetType;
}

public enum TargetType
{
    GrowingSeed,
    Crop,
    Enemy,
}