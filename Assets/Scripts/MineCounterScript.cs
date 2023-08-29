using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MineCounterScript : MonoBehaviour
{
    private GameObject FirstDigit;
    private GameObject SecondDigit;
    private FirstDigitScript FirstDigitLogic;
    private SecondDigitScript SecondDigitLogic;
    private int FlagsLeft { get; set; }
    private LogicScript Logic;
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
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        FirstDigit = GameObject.FindGameObjectWithTag("FirstDigitMine");
        SecondDigit = GameObject.FindGameObjectWithTag("SecondDigitMine");
        FirstDigitLogic = FirstDigit.GetComponent<FirstDigitScript>();
        SecondDigitLogic = SecondDigit.GetComponent<SecondDigitScript>();
        FlagsLeft = Logic.LNumMines;
        UpdateDigitSprites();
    }

    void Update()
    {
        
    }

    public void OnFlagPlaced()
    {
        if (!(FlagsLeft - 1 < 0))
        {
            FlagsLeft--;
            UpdateDigitSprites();
        } 
    }

    public void OnFlagRemoved()
    {
        if (!(FlagsLeft + 1 > 99))
        {
            FlagsLeft++;
            UpdateDigitSprites();
        }

    }

    private void UpdateDigitSprites()
    {
        SpriteType[] disps = GetSpriteTypesFromMines(FlagsLeft);
        FirstDigitLogic.ChangeSprite((FirstDigitScript.SpriteType)disps[0]);
        SecondDigitLogic.ChangeSprite((SecondDigitScript.SpriteType)disps[1]);
    }

    private SpriteType[] GetSpriteTypesFromMines(int mines)
    {
        SpriteType[] ret = new SpriteType[2];
        string digits = mines.ToString();
        if (digits.Length < 2)
        {
            ret[0] = SpriteType.Zero;
            ret[1] = GetSpriteTypeFromString(digits[0].ToString());
        }
        else
        {
            ret[0] = GetSpriteTypeFromString(digits[0].ToString());
            ret[1] = GetSpriteTypeFromString(digits[1].ToString());
        }
        return ret;
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
