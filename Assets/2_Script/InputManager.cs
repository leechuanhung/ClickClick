using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private List<KeyCode> keyCodeList = new List<KeyCode>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddKeyCode(KeyCode keyCode)
    {
        keyCodeList.Add(keyCode);
    }

    private void Update()
    {
        foreach (KeyCode keyCode in keyCodeList)
        {
            if (Input.GetKeyDown(keyCode))
            {
                NoteManager.Instance.OnInput(keyCode);
                break;
            }
        }
    }
}   

    
