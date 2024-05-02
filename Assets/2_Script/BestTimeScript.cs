using UnityEngine;
using UnityEngine.UI;

public class BestTimeScript : MonoBehaviour
{
    public Text bestTimeText;
    private float bestTime;

    void Start()
    {
        // 게임 시작 시 저장된 베스트 타임을 불러옵니다. 없다면 0으로 초기화합니다.
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        UpdateBestTimeText();
    }

    public void UpdateBestTime(float clearTime)
    {
        // 게임 클리어 시간이 현재 베스트 타임보다 빠르다면 베스트 타임을 업데이트하고 저장합니다.
        if (clearTime < bestTime || bestTime == 0f)
        {
            bestTime = clearTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            UpdateBestTimeText();
        }
    }

    public void ResetBestTime()
    {
        // 베스트 타임을 초기화하고 UI를 업데이트합니다.
        bestTime = 0f;
        PlayerPrefs.SetFloat("BestTime", bestTime);
        UpdateBestTimeText();
    }

    void UpdateBestTimeText()
    {
        // 베스트 타임을 분:초 형식으로 변환하여 UI 텍스트 업데이트합니다.
        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        bestTimeText.text = "Best Time: " + timeString;
    }
}
