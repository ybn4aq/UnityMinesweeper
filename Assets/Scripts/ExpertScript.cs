using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ExpertScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent ExpertSelected;
    private GameObject Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic");
    }

    void Update()
    {
        
    }
}
