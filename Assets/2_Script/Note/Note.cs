using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite appleSprie;
    [SerializeField] private Sprite blueberrySprite;

    internal void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    internal void SetSprite(bool isApple)
    {
        spriteRender.sprite = isApple ? appleSprie : blueberrySprite;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
