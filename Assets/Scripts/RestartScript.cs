using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RestartScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D Collide;
    public UnityEvent ShowDifficulties;
    private LogicScript Logic;
    void Start()
    {
        transform.position = new Vector3((float)-0.081, (float)-3.403, 0);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0) && Collide.OverlapPoint(mousePosition))
        {
            ShowDifficulties.Invoke();
        }
    }

    public void OnGameLoss()
    {

    }

    public void OnGameWon()
    {

    }
}
