using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrowingState
{
    Early, 
    Middle,
    Ready,
    Over
}

public class GrowingStateInfo
{
    public GrowingState GrowingState = GrowingState.Early;
    public float TimeToChangeState;
    
    public Action<GrowingState> OnStateEnd = delegate(GrowingState state) {  };
}

public class GrowingSeed : MonoBehaviour
{
    public GrowingState currentState = GrowingState.Early;
    public Seeds seed;

    
}
