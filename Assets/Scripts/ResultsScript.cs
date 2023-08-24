using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] SpriteArray;
    private SpriteRenderer Sprite;
    private GameObject Results;
    private enum SpriteType
    {
        Win,
        Lose,
    }

    void Start()
    {
        Results = GameObject.FindGameObjectWithTag("Results");
        Results.SetActive(false); // TODO: make sure this works
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

    private void ChangeSprite(SpriteType desired)
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
