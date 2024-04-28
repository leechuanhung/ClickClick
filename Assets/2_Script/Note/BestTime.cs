using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    public class GameManager : MonoBehaviour
    {
        public float currentGameTime; // ���� ������ ����� ���� ���� �ð�
        public float bestTime; // ���� Ŭ���� ������ ǥ���� ����Ʈ Ÿ��

        private void Start()
        {
            // ���� Ŭ���� ������ �Ѿ���� �� ����Ʈ Ÿ���� �ε��մϴ�.
            bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        }

        // ���� Ŭ���� ������ ȣ���� �޼���
        public void CheckAndUpdateBestTime()
        {
            // ���� ���� �ð��� ����Ʈ Ÿ�Ӻ��� ������ ����Ʈ Ÿ���� �����մϴ�.
            if (currentGameTime < bestTime)
            {
                bestTime = currentGameTime;
                // ���ŵ� ����Ʈ Ÿ���� �����մϴ�.
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
