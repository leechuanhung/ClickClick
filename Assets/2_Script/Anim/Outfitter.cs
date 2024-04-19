using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolver;
    private CharacterType charType;

    private enum CharacterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolver = GetComponentsInChildren<SpriteResolver>().ToList();
    }

    private void Start()
    {
        ChangeOufit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            charType = charType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOufit();
        }
    }

    private void ChangeOufit()
    {
        foreach (SpriteResolver resolver in resolver)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());
            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            Debug.Log($"sprite : {sprite}");
        }
    }
}
