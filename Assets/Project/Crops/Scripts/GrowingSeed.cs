using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GrowingStateInfo
{
    [Header("Growing Properties")] 
    public string stateName;
    public float timeToChangeState;
    public Sprite stateSprite;
}

public class GrowingSeed : MonoBehaviour
{
    private GrowingStateInfo[] growingStates;
    private int _currentGrowingSeedIndex = 0;

    private Coroutine _growingCoroutine = null;

    public UnityEvent onEndGrowing = new UnityEvent();

    private Seeds currentSeed;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Initialize(BaseItem seed)
    {
        currentSeed = (Seeds)seed;

        growingStates = currentSeed.growingStateInfos;
        
        gameObject.SetActive(true);
        
        StartGrowing(currentSeed);
    }

    private void OnDisable()
    {
        StopGrowingProcess();
    }

    private void StartGrowing(Seeds seed)
    {
        Debug.Log("Growing: " + seed.name);
        var currentGrowingState = growingStates.Length > _currentGrowingSeedIndex ? growingStates[_currentGrowingSeedIndex] : null;

        _growingCoroutine = StartCoroutine(GrowPlant(currentGrowingState));
    }
    
    private IEnumerator GrowPlant(GrowingStateInfo currentGrowingState)
    {
        yield return new WaitForSeconds(currentGrowingState.timeToChangeState);
        Debug.Log("Grow State: " + currentGrowingState.stateName);
        spriteRenderer.sprite = currentGrowingState.stateSprite;

        _currentGrowingSeedIndex++;
        
        currentGrowingState = growingStates.Length > _currentGrowingSeedIndex ? growingStates[_currentGrowingSeedIndex] : null;

        if (currentGrowingState == null)
        {
            onEndGrowing?.Invoke();
            
            Debug.Log("Finish Growing");
            
            yield break;
        }

        _growingCoroutine = StartCoroutine(GrowPlant(currentGrowingState));
    }

    public void StopGrowingProcess()
    {
        StopCoroutine(_growingCoroutine);
    }
}
