using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite appleSprie;
    [SerializeField] private Sprite blueberrySprite;
    [SerializeField] private Sprite redberrySprite;

    private bool isApple;

    internal void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void DeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        Destroy();
    }

    internal void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRender.sprite = isApple ? appleSprie : blueberrySprite;
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
