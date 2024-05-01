using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeycodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F,
        KeyCode.G,KeyCode.H,KeyCode.J,KeyCode.K,KeyCode.L,
    };
    [SerializeField] private int initNoteGroupNum = 2;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
      for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeycodeArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        if (wholeKeycodeArr.Length == noteGroupCount)
            return;
        KeyCode keycode = wholeKeycodeArr[noteGroupCount];
        CreateNoteGroup(keycode);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;
        Debug.Log("noteGroup pos " + noteGroupObj.transform.position);

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }
    public void OnInput(KeyCode keyCode)
    {
        int randid = Random.Range(0, 5);
        bool isApple = randid == 0 ? false : true;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }


    }
}