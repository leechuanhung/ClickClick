using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRender;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    private KeyCode keyCode;
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    internal void OnInput(bool isApple)
    {
        if (noteList.Count > 0)
        {
            Note delNote = noteList[0];
            delNote.DeleteNote();
            noteList.RemoveAt(0);
        }

        for (int i = 0; i < noteList.Count; i++)
        {
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;
        }

        //생성
        SpawnNote(isApple);
        //노트 애니메이션
        anim.Play();
        btnSpriteRender.sprite = selectBtnSprite;
    }

    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            SpawnNote(true);
        }

        InputManager.Instance.AddKeyCode(keyCode);
    }

    private void SpawnNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpawn.transform);
        noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void callAnidone()
    {
        btnSpriteRender.sprite = normalBtnSprite;
    }
}
