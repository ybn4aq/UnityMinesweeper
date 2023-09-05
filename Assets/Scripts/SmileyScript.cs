using UnityEngine;
using UnityEngine.Events;

public class SmileyScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] SpriteArray;
    [SerializeField]
    private SpriteRenderer Sprite;
    public UnityEvent GameRestart;
    [SerializeField]
    private BoxCollider2D Collide;
    private LogicScript Logic;
    private enum SpriteType
    {
        Lose,
        NeutralPressed,
        NeutralUnpressed,
        Win,
        Surprised,
    }
    void Start()

    {
        ChangeSprite(SpriteType.NeutralUnpressed);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        GameRestart.AddListener(Logic.OnGameRestart);
    }

    void Update()
    {
        // TODO: fix bug where sprite stays pressed when u hold click and then dont release while on the tile
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Collide.OverlapPoint(mousePosition))
        {
            ChangeSprite(SpriteType.NeutralPressed);
        }
        if (Input.GetMouseButtonUp(0) && Collide.OverlapPoint(mousePosition))
        {
            ChangeSprite(SpriteType.NeutralUnpressed);
            GameRestart.Invoke();
        }
    }

    private void HandleLeftClick()
    {

    }

    private void ChangeSprite(SpriteType desiredType)
    {
        if (desiredType == SpriteType.Lose)
        {
            Sprite.sprite = SpriteArray[0];
        }
        else if (desiredType == SpriteType.NeutralPressed)
        {
            Sprite.sprite = SpriteArray[1];
        }
        else if (desiredType == SpriteType.NeutralUnpressed)
        {
            Sprite.sprite = SpriteArray[2];
        }
        else if (desiredType == SpriteType.Win)
        {
            Sprite.sprite = SpriteArray[3];
        }
        else if (desiredType == SpriteType.Surprised)
        {
            Sprite.sprite = SpriteArray[4];
        }
    }

    public void OnGameWon()
    {
        ChangeSprite(SpriteType.Win);
    }
    public void OnGameLoss()
    {
        ChangeSprite(SpriteType.Lose);
    }
}
