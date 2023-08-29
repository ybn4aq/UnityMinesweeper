using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDigitTimerScript : MonoBehaviour
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
}
