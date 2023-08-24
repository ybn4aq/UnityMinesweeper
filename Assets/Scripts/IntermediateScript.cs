using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IntermediateScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent IntermediateSelected;
    private GameObject Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic");
    }

    void Update()
    {
        
    }
}
