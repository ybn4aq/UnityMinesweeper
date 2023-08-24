using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultiesScript : MonoBehaviour
{
    private GameObject Easy;
    private GameObject Intermediate;
    private GameObject Expert;

    void Start()
    {
        Easy = GameObject.FindGameObjectWithTag("Easy");
        Intermediate = GameObject.FindGameObjectWithTag("Intermediate");
        Expert = GameObject.FindGameObjectWithTag("Expert");
        
    }
    
    // idea: wait until user clicks or presses a key in order to show difficulties

    void Update()
    {
        
    }

    public void OnShowDifficulties()
    {
        // TODO: Show all difficulty buttons
    }
}
