using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameExit()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
