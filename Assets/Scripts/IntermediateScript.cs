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
    private UIScript UIScript;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        IntermediateSelected.AddListener(Logic.OnIntermediateSelected);
        UIScript = GameObject.FindGameObjectWithTag("UIScript").GetComponent<UIScript>();
        IntermediateSelected.AddListener(UIScript.OnIntermediateSelected);
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0) && Collide.OverlapPoint(mousePosition))
        {
            IntermediateSelected.Invoke();
        }
    }
}
