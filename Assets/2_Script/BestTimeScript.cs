using UnityEngine;
using UnityEngine.UI;

public class BestTimeScript : MonoBehaviour
{
    public Text bestTimeText;
    private float bestTime;

    void Start()
    {
        // ���� ���� �� ����� ����Ʈ Ÿ���� �ҷ��ɴϴ�. ���ٸ� 0���� �ʱ�ȭ�մϴ�.
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        UpdateBestTimeText();
    }

    public void UpdateBestTime(float clearTime)
    {
        // ���� Ŭ���� �ð��� ���� ����Ʈ Ÿ�Ӻ��� �����ٸ� ����Ʈ Ÿ���� ������Ʈ�ϰ� �����մϴ�.
        if (clearTime < bestTime || bestTime == 0f)
        {
            bestTime = clearTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            UpdateBestTimeText();
        }
    }

    public void ResetBestTime()
    {
        // ����Ʈ Ÿ���� �ʱ�ȭ�ϰ� UI�� ������Ʈ�մϴ�.
        bestTime = 0f;
        PlayerPrefs.SetFloat("BestTime", bestTime);
        UpdateBestTimeText();
    }

    void UpdateBestTimeText()
    {
        // ����Ʈ Ÿ���� ��:�� �������� ��ȯ�Ͽ� UI �ؽ�Ʈ ������Ʈ�մϴ�.
        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        bestTimeText.text = "Best Time: " + timeString;
    }
}
