using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] SpriteArray;
    [SerializeField]
    private SpriteRenderer Sprite;
    private GameObject Results;
    public enum SpriteType
    {
        Win,
        Lose,
    }

    void Start()
    {
        transform.position = new Vector3(0, 8.94f, 0);
        Results = GameObject.FindGameObjectWithTag("Results");
    }

    void Update()
    {
        
    }

    public void OnGameWon()
    {
        ChangeSprite(SpriteType.Win);
    }

    public void OnGameLose()
    {
        ChangeSprite(SpriteType.Lose);
    }

    public void ChangeSprite(SpriteType desired)
    {
        if (desired == SpriteType.Lose)
        {
            Sprite.sprite = SpriteArray[0];
        }
        else
        {
            Sprite.sprite = SpriteArray[1];
        }
    }
}
