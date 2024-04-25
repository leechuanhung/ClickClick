using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] audioClips; // ���� ����� Ŭ���� ������ �迭

    private AudioSource[] audioSources; // ���� ����� �ҽ��� ������ �迭

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // ����� Ŭ���� ������ŭ ����� �ҽ� ����
        audioSources = new AudioSource[audioClips.Length];

        // �� ����� �ҽ��� ����� Ŭ�� �Ҵ�
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
        }
    }

   
    public void Sound()
    {
        audioSources[0].Play();
    }
}
