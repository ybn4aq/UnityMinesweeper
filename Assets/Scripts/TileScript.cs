using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BoxCollider2D collide;
    void Start()
    {
        
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // check for single left click
        if (Input.GetMouseButtonUp(0) && collide.OverlapPoint(mousePosition)) 
        {
            HandleSingleLeftClick();
        }
        else if (Input.GetMouseButtonUp(1) && collide.OverlapPoint(mousePosition))
        {
            HandleRightClick();
        }
    }

    void HandleSingleLeftClick()
    {
        Debug.Log("Single left click!");
    }

    void HandleRightClick()
    {
        Debug.Log("Right click!");
    }

    void HandleDoubleLeftClick()
    {
        Debug.Log("Double left click!");
    }
}
