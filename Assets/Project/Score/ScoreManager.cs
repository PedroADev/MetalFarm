using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Score score;

    public float multiplier = 1;

    [SerializeField] private TMP_Text scoreText;

    public void Initialize()
    {
        score = new Score();

        UpdateScoreText();
    }

    private void AddScore(float points)
    {
        score.value += points * multiplier;

        UpdateScoreText();
    }

    private void OnEnable()
    {
        OrderManager.OnOrderDelivered += GetOrderScore;
    }

    private void OnDisable()
    {
        OrderManager.OnOrderDelivered -= GetOrderScore;
    }

    private void GetOrderScore(Order order)
    {
        AddScore(order.orderScore);
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.value.ToString(CultureInfo.InvariantCulture);
    }
}

[Serializable]
public struct Score
{
    public float value;
}
