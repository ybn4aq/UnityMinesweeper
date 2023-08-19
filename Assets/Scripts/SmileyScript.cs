using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] SpriteArray;
    [SerializeField]
    private SpriteRenderer Sprite;
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
        
    }
    
    void Update()
    {
        
    }


    public void OnGameWon()
    {

    }
    public void OnGameLoss()
    {

    }
}
