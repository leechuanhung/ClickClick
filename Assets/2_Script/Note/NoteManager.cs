using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] initleyCodeArr;
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        foreach (KeyCode keyCode in initleyCodeArr)
        {
            CreateNoteGroup(keyCode);
        }
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
        int randid = Random.Range(0, noteGroupList.Count);
        bool isApple = randid == 0 ? false : true;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }


    }
}