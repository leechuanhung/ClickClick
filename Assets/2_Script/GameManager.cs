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


    //���� ������ ����� ���� ���� �ð�
    public float currentGameTime;

    //���� Ŭ���� ������ ǥ���� ����Ʈ Ÿ��
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

        //���� Ŭ���� ������ �Ѿ���� �� ����Ʈ Ÿ���� �ε��Ѵ�.
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

    //���� Ŭ���� ������ ȣ���� �޼���
    public void CheckAndUpdateBestTime()
    {
        //���� ���� �ð��� ����Ʈ Ÿ�Ӻ��� ������ ����Ʈ Ÿ���� �����մϴ�.
        if (currentGameTime < bestTime)
        {
            bestTime = currentGameTime;
            //���ŵ� ����Ʈ Ÿ���� �����մϴ�.
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
