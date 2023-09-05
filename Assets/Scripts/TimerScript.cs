using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private FirstDigitTimerScript FirstDigit;
    private SecondDigitTimerScript SecondDigit;
    private ThirdDigitTimerScript ThirdDigit;
    private float Timer = 0f;
    private const float WaitTime = 1.0f;
    private int CurTime = 0;
    private bool RunTimer { get; set; } = true;
    public enum SpriteType
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Blank,
    }
   
    void Start()
    {
        FirstDigit = GameObject.FindGameObjectWithTag("FirstDigitTimer").GetComponent<FirstDigitTimerScript>();
        SecondDigit = GameObject.FindGameObjectWithTag("SecondDigitTimer").GetComponent<SecondDigitTimerScript>();
        ThirdDigit = GameObject.FindGameObjectWithTag("ThirdDigitTimer").GetComponent<ThirdDigitTimerScript>();
    }

    void Update()
    {
        if (RunTimer)
        {
            Timer += Time.deltaTime;
            if (Timer >= WaitTime && CurTime < 999)
            {
                IncrementTime();
                Timer = 0f;
            }
        }
    }

    void IncrementTime()
    {
        CurTime++;
        ChangeTime();
    }

    void ChangeTime()
    {
        SpriteType[] disps = GetSpriteTypesFromTime();
        FirstDigit.ChangeSprite(disps[0]);
        SecondDigit.ChangeSprite(disps[1]);
        ThirdDigit.ChangeSprite(disps[2]);
    }

    SpriteType[] GetSpriteTypesFromTime()
    {
        SpriteType[] ret = new SpriteType[3];
        string digits = CurTime.ToString();
        if (digits.Length == 1)
        {
            ret[2] = SpriteType.Zero;
            ret[1] = SpriteType.Zero;
            ret[0] = GetSpriteTypeFromString(digits[0].ToString());
            
        }
        else if (digits.Length == 2)
        {
            ret[2] = SpriteType.Zero;
            ret[1] = GetSpriteTypeFromString(digits[0].ToString());
            ret[0] = GetSpriteTypeFromString(digits[1].ToString());
        }
        else // digits.Length == 3
        {
            ret[2] = GetSpriteTypeFromString(digits[0].ToString());
            ret[1] = GetSpriteTypeFromString(digits[1].ToString());
            ret[0] = GetSpriteTypeFromString(digits[2].ToString());
        }
        return ret;
    }

    public void OnGameWon() // TODO: add listener
    {
        RunTimer = false;
    }

    public void OnGameLoss()
    {
        RunTimer = false;
    }
    private SpriteType GetSpriteTypeFromString(string digit)
    {
        if (digit == "0")
        {
            return SpriteType.Zero;
        }
        else if (digit == "1")
        {
            return SpriteType.One;
        }
        else if (digit == "2")
        {
            return SpriteType.Two;
        }
        else if (digit == "3")
        {
            return SpriteType.Three;
        }
        else if (digit == "4")
        {
            return SpriteType.Four;
        }
        else if (digit == "5")
        {
            return SpriteType.Five;
        }
        else if (digit == "6")
        {
            return SpriteType.Six;
        }
        else if (digit == "7")
        {
            return SpriteType.Seven;
        }
        else if (digit == "8")
        {
            return SpriteType.Eight;
        }
        else if (digit == "9")
        {
            return SpriteType.Nine;
        }
        else
        {
            return SpriteType.Blank;
        }
    }
}
