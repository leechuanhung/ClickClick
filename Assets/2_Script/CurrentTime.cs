using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    public static float bestTime = 0;

    void Start()
    {
        GetComponent<Text>().text = "Best Time : " + Time.time.ToString();
        bestTime = 0;
    }


    void Update()
    {
        if (Time.time > bestTime)
        {
            Time.captureDeltaTime = bestTime;
        }
    }
}
