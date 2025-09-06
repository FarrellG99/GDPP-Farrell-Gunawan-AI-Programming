using System;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int _score;
    private int _maxScore;

    private void Start()
    {
        _score = 0;
        _maxScore = 0;
        UpdateUi();
    }

    public void UpdateUi()
    {
        scoreText.text = "Score: " + _score +  " / " + _maxScore;
    }

    public void SetMaxScore(int maxScore)
    {
        _maxScore = maxScore;
        UpdateUi();
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateUi();
    }
}