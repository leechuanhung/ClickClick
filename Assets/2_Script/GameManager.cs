using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxScore)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;
        }

        Debug.Log("Game Over..............");
    }

    internal void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if(noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
        } else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }
}
