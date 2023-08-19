using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    [SerializeField] public BoardScript boardScript;
    void Start()
    {
        boardScript = GetComponent<BoardScript>();
    }

    void Update()
    {
        
    }
}
