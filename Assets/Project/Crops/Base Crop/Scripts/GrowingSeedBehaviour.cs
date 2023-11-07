using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GrowingStateInfo
{
    [Header("Growing Properties")] 
    public float timeToChangeState;
    public string animationName;
}

public class GrowingSeedBehaviour : MonoBehaviour
{
    private GrowingStateInfo[] growingStates;
    private int _currentGrowingSeedIndex = 0;

    private Coroutine _growingCoroutine = null;

    public UnityEvent<Crops> onEndGrowing = new UnityEvent<Crops>();

    private Seeds currentSeed;
    private Crop _growingCrop;

    public void Initialize(BaseItem seed)
    {
        currentSeed = (Seeds)seed;

        growingStates = currentSeed.cropToGrow.growingStateInfos;
    }

    private void OnEnable()
    {
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

        _growingCrop = Instantiate(currentSeed.cropToGrow.cropPrefab, transform.position, quaternion.identity);
        _growingCoroutine = StartCoroutine(GrowPlant(currentGrowingState));
    }
    
    private IEnumerator GrowPlant(GrowingStateInfo currentGrowingState)
    {
        yield return new WaitForSeconds(currentGrowingState.timeToChangeState);

        _currentGrowingSeedIndex++;
        
        currentGrowingState = growingStates.Length > _currentGrowingSeedIndex ? growingStates[_currentGrowingSeedIndex] : null;
        
        if (currentGrowingState == null)
        {
            _growingCrop.OnCropReady();
            onEndGrowing?.Invoke(currentSeed.cropToGrow);

            gameObject.SetActive(false);
            
            yield break;
        }
        
        _growingCrop.ChangeState(currentGrowingState);

        _growingCoroutine = StartCoroutine(GrowPlant(currentGrowingState));
    }

    private void StopGrowingProcess()
    {
        if(_growingCoroutine != null) StopCoroutine(_growingCoroutine);
    }
}
