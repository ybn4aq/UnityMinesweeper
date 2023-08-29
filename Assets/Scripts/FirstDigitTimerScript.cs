using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDigitTimerScript : MonoBehaviour
{
    private TimerScript Timer;
    [SerializeField]
    private SpriteRenderer Sprite;
    [SerializeField]
    private Sprite[] SpriteArray;
    void Start()
    {
        Timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }

    void Update()
    {
        
    }

    public void ChangeSprite(TimerScript.SpriteType desired)
    {
        if (desired == SpriteType.Zero)
        {
            Sprite.sprite = SpriteArray[0];
        }
        else if (desired == SpriteType.One)
        {
            Sprite.sprite = SpriteArray[1];
        }
        else if (desired == SpriteType.Two)
        {
            Sprite.sprite = SpriteArray[2];
        }
        else if (desired == SpriteType.Three)
        {
            Sprite.sprite = SpriteArray[3];
        }
        else if (desired == SpriteType.Four)
        {
            Sprite.sprite = SpriteArray[4];
        }
        else if (desired == SpriteType.Five)
        {
            Sprite.sprite = SpriteArray[5];
        }
        else if (desired == SpriteType.Six)
        {
            Sprite.sprite = SpriteArray[6];
        }
        else if (desired == SpriteType.Seven)
        {
            Sprite.sprite = SpriteArray[7];
        }
        else if (desired == SpriteType.Eight)
        {
            Sprite.sprite = SpriteArray[8];
        }
        else if (desired == SpriteType.Nine)
        {
            Sprite.sprite = SpriteArray[9];
        }
        else
        {
            Sprite.sprite = SpriteArray[10];
        }
    }
}
