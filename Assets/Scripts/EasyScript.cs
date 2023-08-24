using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EasyScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent EasySelected;
    private LogicScript Logic;
    private UIScript UIScript;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        EasySelected.AddListener(Logic.OnEasySelected);
        UIScript = GameObject.FindGameObjectWithTag("UIScript").GetComponent<UIScript>();
        EasySelected.AddListener(UIScript.OnEasySelected);
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0) && Collide.OverlapPoint(mousePosition))
        {
            EasySelected.Invoke();
        }
    }
}
