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
    private UIScript UIScript;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ExpertSelected.AddListener(Logic.OnExpertSelected);
        UIScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        ExpertSelected.AddListener(UIScript.OnExpertSelected);
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0) && Collide.OverlapPoint(mousePosition))
        {
            ExpertSelected.Invoke();
        }
    }
}
