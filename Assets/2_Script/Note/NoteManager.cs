using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void OnInput(KeyCode keyCode)
    {
        Debug.Log("Keycode = " + keyCode);
    }
}