using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    
    [SerializeField] private UnityEvent startLevel = new UnityEvent();
    [SerializeField] private int timeToStartLevel = 3;

    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private UnityEvent endLevel = new UnityEvent();

    private WaitForSeconds _oneSecond = new WaitForSeconds(1);
    
    private IEnumerator Start()
    {
        while (timeToStartLevel > 0)
        {
            UpdateCountdownText(timeToStartLevel.ToString());
            
            yield return _oneSecond;
            
            timeToStartLevel -= 1;
        }

        yield return null;
        
        UpdateCountdownText("GO!");

        yield return _oneSecond;
        
        startLevel?.Invoke();

        StartCoroutine(RunLevelTime());
    }

    private void UpdateCountdownText(string text)
    {
        countdownText.text = text;
    }

    private IEnumerator RunLevelTime()
    {
        var levelTime = levelData.timeToCompleteLevel;
        
        while (levelTime > 0)
        {
            int minutes = Mathf.FloorToInt(levelTime / 60F);
            int seconds = Mathf.FloorToInt(levelTime - minutes * 60);

            timerText.text  = $"{minutes:0}:{seconds:00}";
            
            yield return _oneSecond;
            
            levelTime--;
        }
        
        endLevel?.Invoke();
    }
}
