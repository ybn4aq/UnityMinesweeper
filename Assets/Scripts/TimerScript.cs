using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private FirstDigitTimerScript FirstDigit;
    private SecondDigitTimerScript SecondDigit;
    private ThirdDigitTimerScript ThirdDigit;
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

    }

    void IncrementTime()
    {

    }
}
