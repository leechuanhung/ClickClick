using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    public class GameManager : MonoBehaviour
    {
        public float currentGameTime; // 메인 씬에서 기록한 현재 게임 시간
        public float bestTime; // 게임 클리어 씬에서 표시할 베스트 타임

        private void Start()
        {
            // 게임 클리어 씬으로 넘어왔을 때 베스트 타임을 로드합니다.
            bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        }

        // 게임 클리어 씬에서 호출할 메서드
        public void CheckAndUpdateBestTime()
        {
            // 현재 게임 시간이 베스트 타임보다 작으면 베스트 타임을 갱신합니다.
            if (currentGameTime < bestTime)
            {
                bestTime = currentGameTime;
                // 갱신된 베스트 타임을 저장합니다.
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
