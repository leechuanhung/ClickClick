using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
                return false;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

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

            if (IsGameDone)
            {
                yield break;
            }
        }

        gameOverObj.SetActive(true);
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
            if(maxScore <= score)
            {
                gameClearObj.SetActive(true);
            }
        } 
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

public void Restart()
    {
        Debug.Log("Game Restart!.........");
        SceneManager.LoadScene(0);
    }
}
