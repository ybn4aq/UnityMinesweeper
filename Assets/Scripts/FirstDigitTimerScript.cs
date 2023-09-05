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
        ChangeSprite(TimerScript.SpriteType.Zero);
    }

    void Update()
    {
        
    }

    public void ChangeSprite(TimerScript.SpriteType desired)
    {
        if (desired == TimerScript.SpriteType.Zero)
        {
            Sprite.sprite = SpriteArray[0];
        }
        else if (desired == TimerScript.SpriteType.One)
        {
            Sprite.sprite = SpriteArray[1];
        }
        else if (desired == TimerScript.SpriteType.Two)
        {
            Sprite.sprite = SpriteArray[2];
        }
        else if (desired == TimerScript.SpriteType.Three)
        {
            Sprite.sprite = SpriteArray[3];
        }
        else if (desired == TimerScript.SpriteType.Four)
        {
            Sprite.sprite = SpriteArray[4];
        }
        else if (desired == TimerScript.SpriteType.Five)
        {
            Sprite.sprite = SpriteArray[5];
        }
        else if (desired == TimerScript.SpriteType.Six)
        {
            Sprite.sprite = SpriteArray[6];
        }
        else if (desired == TimerScript.SpriteType.Seven)
        {
            Sprite.sprite = SpriteArray[7];
        }
        else if (desired == TimerScript.SpriteType.Eight)
        {
            Sprite.sprite = SpriteArray[8];
        }
        else if (desired == TimerScript.SpriteType.Nine)
        {
            Sprite.sprite = SpriteArray[9];
        }
        else
        {
            Sprite.sprite = SpriteArray[10];
        }
    }
}
