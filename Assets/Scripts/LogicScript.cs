using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

    private BoardScript boardScript;
    // Start is called before the first frame update
    void Start()
    {
        boardScript = GetComponent<BoardScript>();
        for (int i = 0; i < boardScript.rows; i++)
        {
            for (int j = 0; i < boardScript.cols; j++)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
