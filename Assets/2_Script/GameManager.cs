using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();
    }

    internal void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
        } else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }
}
