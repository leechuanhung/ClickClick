using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] audioClips; // 여러 오디오 클립을 저장할 배열

    private AudioSource[] audioSources; // 여러 오디오 소스를 저장할 배열

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 오디오 클립의 개수만큼 오디오 소스 생성
        audioSources = new AudioSource[audioClips.Length];

        // 각 오디오 소스에 오디오 클립 할당
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
