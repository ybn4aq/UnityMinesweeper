using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IntermediateScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent IntermediateSelected;
    private LogicScript Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        IntermediateSelected.AddListener(Logic.OnIntermediateSelected);
    }

    void Update()
    {
        
    }
}
