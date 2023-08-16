using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BoxCollider2D collide;
    public Sprite[] spriteArray;
    public Tile AssociatedTile;
    public UnityEvent BlankDug;
    public UnityEvent MineDug;
    public UnityEvent FlagPlaced;
    public UnityEvent MineFlagged;
    public UnityEvent FlagRemoved;
    public enum SpriteType
    {
        Unmined,
        Num0,
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Mine,
        Flag,
        FalseMine,
        MineRed,
    }
    void Start()
    {
        ChangeSprite(SpriteType.Unmined);
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

    public void ChangeSprite(SpriteType desired)
    {
        if (desired == SpriteType.Unmined)
        {
            sprite.sprite = spriteArray[0];
        }
        else if (desired == SpriteType.Num0)
        {
            sprite.sprite = spriteArray[1];
        }
        else if (desired == SpriteType.Num1)
        {
            sprite.sprite = spriteArray[2];
        }
        else if (desired == SpriteType.Num2)
        {
            sprite.sprite = spriteArray[3];
        }
        else if (desired == SpriteType.Num3)
        {
            sprite.sprite = spriteArray[4];
        }
        else if (desired == SpriteType.Num4)
        {
            sprite.sprite = spriteArray[5];
        }
        else if (desired == SpriteType.Num5)
        {
            sprite.sprite = spriteArray[6];
        }
        else if (desired == SpriteType.Num6)
        {
            sprite.sprite = spriteArray[7];
        }
        else if (desired == SpriteType.Num7)
        {
            sprite.sprite = spriteArray[8];
        }
        else if (desired == SpriteType.Num8)
        {
            sprite.sprite = spriteArray[9];
        }
        else if (desired == SpriteType.Mine)
        {
            sprite.sprite = spriteArray[12];
        }
        else if (desired == SpriteType.FalseMine)
        {
            sprite.sprite = spriteArray[11];
        }
        else if (desired == SpriteType.Flag)
        {
            sprite.sprite = spriteArray[10];
        }
        else if (desired == SpriteType.MineRed)
        {
            sprite.sprite = spriteArray[13];
        }
    }

    void HandleSingleLeftClick()
    {
        Debug.Log("Single left click!");
        if (!AssociatedTile.IsDug && !AssociatedTile.IsFlagged) // can't dig a tile that's flagged
        {
            if (AssociatedTile.IsMine)
            {
                MineDug.Invoke();
                AssociatedTile.IsDug = true; // may not be necessary
            }
            else
            {
                BlankDug.Invoke();
                AssociatedTile.IsDug = true;
            }
        }
    }

    void HandleRightClick()
    {
        Debug.Log("Right click!");
        if (!AssociatedTile.IsDug)
        {
            if (!AssociatedTile.IsFlagged)
            {
                FlagPlaced.Invoke();
                if (AssociatedTile.IsMine)
                {
                    MineFlagged.Invoke();
                    AssociatedTile.IsFlagged = true;
                }
            }
            else
            {
                FlagRemoved.Invoke();
                AssociatedTile.IsFlagged = false;
            }
        }
    }

    void HandleDoubleLeftClick()
    {
        Debug.Log("Double left click!");
    }
}

public class Tile
{
    public bool IsDug { get; set; }
    public bool IsMine { get; set; }
    public bool IsFlagged { get; set; }
    public int AdjMines { get; set; }

    public Tile(bool isMine)
    {
        IsMine = isMine;
        AdjMines = 0;
        IsDug = false;
        IsFlagged = false;
    }

    public virtual void IncrementAdjMines()
    {
        AdjMines++;
    }
}