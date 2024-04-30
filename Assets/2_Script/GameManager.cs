using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;

    private int score;
    private int nextNoteGroupUnlockCnt;


    //메인 씬에서 기록한 현재 게임 시간
    public float currentGameTime;

    //게임 클리어 씬에서 표시할 베스트 타임
    public float bestTime;

    [SerializeField] private float maxTime = 30f;
    [HideInInspector] public static float myTime;
    [HideInInspector] public static float minTime;

    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {
                float minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime > myTime)
                {
                    minTime = myTime;
                }
                SceneManager.LoadScene("GameOverSecene");
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    private void Awake()
    {
        Instance = this;
        minTime = PlayerPrefs.GetFloat("minTime");
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCouroutine());

        //게임 클리어 씬으로 넘어왔을 때 베스트 타임을 로드한다.
        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
    }

    IEnumerator TimerCouroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            myTime = currentTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        isGameOver = true;
        {
            if (isGameOver)
            {
                SceneManager.LoadScene("GameOverScene");
            }

        }

    }

    internal void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();

            }
            if (maxScore <= score)
            {
                isGameClear = true;
                {
                    if (isGameClear)
                    {
                        SceneManager.LoadScene("GameClearScene");
                    }
                }
            }
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    //게임 클리어 씬에서 호출할 메서드
    public void CheckAndUpdateBestTime()
    {
        //현대 게임 시간이 베스트 타임보다 작으면 베스트 타임을 갱신합니다.
        if (currentGameTime < bestTime)
        {
            bestTime = currentGameTime;
            //갱신된 베스트 타임을 저장합니다.
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetFloat("BestTime"));
        }
    }
    public void Restart()
    {
        Debug.Log("Game Restart!.........");
        SceneManager.LoadScene(0);
    }
}
