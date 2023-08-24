using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EasyScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent EasySelected;
    private GameObject Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic");
    }

    void Update()
    {
        
    }
}
