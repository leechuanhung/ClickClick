using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutinTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }
    IEnumerator TimerCoroutine()
    {
        int counter = 0;

        Debug.Log(counter);
        counter++;
        yield return new WaitForSeconds(1);

        Debug.Log(counter);
        counter = 0;
        yield return new WaitForSeconds(1);

        Debug.Log(counter);
        counter = 0;
        yield return new WaitForSeconds(1);

        Debug.Log("³¡");
    }

}
