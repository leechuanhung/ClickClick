using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NoteManager.Instance.OnInput(KeyCode.A);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            NoteManager.Instance.OnInput(KeyCode.S);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            NoteManager.Instance.OnInput(KeyCode.D);
        }
    }
}   

    
