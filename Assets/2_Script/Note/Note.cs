using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite appleSprie;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;
    private bool isBlueberry;

    internal void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void DeleteNote()
    {
        if (this.isApple)
        {
            SoundManager.Instance.Sound();
        }
        if (this.isBlueberry)
        {
            SoundManager.Instance.Sound();
        }
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
