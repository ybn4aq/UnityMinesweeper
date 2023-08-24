using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ExpertScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent ExpertSelected;
    private LogicScript Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ExpertSelected.AddListener(Logic.OnExpertSelected);
    }

    void Update()
    {
        
    }
}
