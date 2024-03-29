using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private NoteGroup[] noteGroupArr;

    private void Awake()
    {
        Instance = this;
    }
    public void OnInput(KeyCode keyCode)
    {
        if (keyCode == KeyCode.A)
        {
            noteGroupArr[0].OnInput(true);
        }
        if (keyCode == KeyCode.S)
        {
            noteGroupArr[1].OnInput(true);
        }
    }
}