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
    private enum SpriteType
    {
        Win,
        Lose,
    }

    void Start()
    {
        transform.position = new Vector3((float)2.11, (float)5.94, 0);
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
        transform.position = new Vector3((float)2.11, (float)5.94, 0);
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
