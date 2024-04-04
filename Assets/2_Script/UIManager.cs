using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    private void Awake()
    {
        Instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;
    }
}