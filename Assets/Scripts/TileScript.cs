using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    // TODO: go through and make any fields or methods private that you can
    // TODO: use a spritesheet for sprites to save space
    public SpriteRenderer sprite;
    public BoxCollider2D collide;
    public Sprite[] spriteArray;
    public Tile AssociatedTile;
    private MineCounterScript MineCounter;
    public UnityEvent BlankDug;
    public UnityEvent MineDug;
    public UnityEvent BlankFlagged;
    public UnityEvent MineFlagged;
    public UnityEvent BlankUnflagged;
    public UnityEvent MineUnFlagged;
    public UnityEvent TileBeingClicked; // to make smiley face look shocked
    public bool IsGameLoss;
    public bool IsGameWon;
    private float DoubleClickTime = .2f;
    private float LastClickTime { get; set; }
    public BoardScript boardScript { get; set; }
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
        Question,
    }

    void Start()
    {
        ChangeSprite(SpriteType.Unmined);
        IsGameWon = false;
        MineCounter = GameObject.FindGameObjectWithTag("MineCounter").GetComponent<MineCounterScript>();
        IsGameLoss = false;
        BlankDug.AddListener(boardScript.OnBlankDug);
        MineDug.AddListener(boardScript.OnMineDug);
        BlankFlagged.AddListener(boardScript.OnBlankFlagged);
        MineFlagged.AddListener (boardScript.OnMineFlagged);
        BlankUnflagged.AddListener(boardScript.OnBlankUnFlagged);
        MineUnFlagged.AddListener(boardScript.OnMineUnFlagged);
        BlankFlagged.AddListener(MineCounter.OnFlagPlaced);
        MineFlagged.AddListener(MineCounter.OnFlagPlaced);
        MineUnFlagged.AddListener(MineCounter.OnFlagRemoved);
        BlankUnflagged.AddListener(MineCounter.OnFlagRemoved);
        // TODO: remove listeners later
    }

    void Update()
    {
        if (!IsGameLoss && !IsGameWon) // only handle tile interactions during gameplay
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool shiftClick = Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonUp(0) && collide.OverlapPoint(mousePosition);
            bool spaceClick = Input.GetKey(KeyCode.Space) && Input.GetMouseButtonUp(0) && collide.OverlapPoint(mousePosition);
            if (spaceClick)
            {
                HandleSweepClick();
            }
            else if ((Input.GetMouseButtonUp(1) && collide.OverlapPoint(mousePosition)) || shiftClick)
            {
                HandleRightClick();
            }
            else if (Input.GetMouseButtonUp(0) && collide.OverlapPoint(mousePosition))
            {
                float timeSinceLastClick = Time.time - LastClickTime;
                if (timeSinceLastClick <= DoubleClickTime)
                {
                    HandleSweepClick();
                }
                else
                {
                    HandleSingleLeftClick();
                }
                LastClickTime = Time.time;
            }
        }
    }

    public void OnGameLoss()
    {
        IsGameLoss = true;
        if (AssociatedTile.IsMine)
        {
            if (!AssociatedTile.IsFlagged)
            {
                ChangeSprite(SpriteType.Mine);
            }
        }
        else if (AssociatedTile.IsFlagged)
        {
            ChangeSprite(SpriteType.FalseMine);
        }
    }

    public void OnGameWon()
    {
        IsGameWon = true;
    }

    public void OnGameRestart() // may not even be necessary, i think all tile prefabs are destroyed
    {
        IsGameLoss = false;
        IsGameWon = false;
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
        else if (desired == SpriteType.Question)
        {
            sprite.sprite = spriteArray[14];
        }
    }

    void HandleSingleLeftClick()
    {
        if (!AssociatedTile.IsDug && !AssociatedTile.IsFlagged) // can't dig a tile that's flagged
        {
            if (AssociatedTile.IsMine)
            {
                DigMine();
            }
            else
            {
                DigBlank();
            }
        }
    }

    void HandleSweepClick()
    {
        if (AssociatedTile.IsDug)
        {
            Tile cur;
            int numFlagsTouched = 0;
            for (int i = 0; i < AssociatedTile.AdjacentTiles.Count; i++)
            {
                cur = AssociatedTile.AdjacentTiles[i];
                if (cur.IsFlagged)
                {
                    numFlagsTouched++;
                }
            }
            if (numFlagsTouched == AssociatedTile.AdjMines)
            {
                for (int i = 0; i < AssociatedTile.AdjacentTiles.Count; i++)
                {
                    cur = AssociatedTile.AdjacentTiles[i];
                    if (!cur.IsDug && !cur.IsFlagged)
                    {
                        if (!cur.IsMine)
                        {
                            cur.AssociatedTileScript.DigBlank();
                        }
                        else
                        {
                            cur.AssociatedTileScript.DigMine(); // I realize this is a bizarre way to implement this. There should just be a Dig() function
                        }
                    }
                }
            }
            
        }
    }

    void DigMine()
    {
        MineDug.Invoke();
        AssociatedTile.IsDug = true; // may not be necessary
        ChangeSprite(SpriteType.MineRed);
    }

    void DigBlank()
    {
        BlankDug.Invoke();
        AssociatedTile.IsDug = true;
        ChangeSprite(GetBlankSpriteChange());
        // if 0 tile, mine all adjacent 0 tiles
        if (AssociatedTile.AdjMines == 0 && !AssociatedTile.IsMine)
        {
            Tile cur;
            for (int i = 0; i < AssociatedTile.AdjacentTiles.Count; i++)
            {
                cur = AssociatedTile.AdjacentTiles[i];
                if (!cur.IsDug && !cur.IsFlagged)
                {
                    cur.AssociatedTileScript.DigBlank();
                }
            }
        }
    }

    void HandleRightClick()
    {
        if (!AssociatedTile.IsDug) // can't flag a dug tile
        {
            if (!AssociatedTile.IsFlagged)
            {
                Flag();
            }
            else
            {
                UnFlag();
            }
        }
    }

    void Flag()
    {
        AssociatedTile.IsFlagged = true;
        ChangeSprite(SpriteType.Flag);
        if (AssociatedTile.IsMine)
        {
            MineFlagged.Invoke();
        }
        else
        {
            BlankFlagged.Invoke();
        }
    }

    void UnFlag()
    {
        AssociatedTile.IsFlagged = false;
        ChangeSprite(SpriteType.Unmined);
        if (AssociatedTile.IsMine)
        {
            MineUnFlagged.Invoke();
        }
        else
        {
            BlankUnflagged.Invoke();
        }
    }
    SpriteType GetBlankSpriteChange()
    {
        if (AssociatedTile.AdjMines == 0)
        {
            return SpriteType.Num0;
        }
        if (AssociatedTile.AdjMines == 1)
        {
            return SpriteType.Num1;
        }
        if (AssociatedTile.AdjMines == 2)
        {
            return SpriteType.Num2;
        }
        if (AssociatedTile.AdjMines == 3)
        {
            return SpriteType.Num3;
        }
        if (AssociatedTile.AdjMines == 4)
        {
            return SpriteType.Num4;
        }
        if (AssociatedTile.AdjMines == 5)
        {
            return SpriteType.Num5;
        }
        if (AssociatedTile.AdjMines == 6)
        {
            return SpriteType.Num6;
        }
        if (AssociatedTile.AdjMines == 7)
        {
            return SpriteType.Num7;
        }
        else
        {
            return SpriteType.Num8;
        }
    }

}


public class Tile
{
    public bool IsDug { get; set; }
    public bool IsMine { get; set; }
    public bool IsFlagged { get; set; }
    public int AdjMines { get; set; }
    public List<Tile> AdjacentTiles { get; set; }
    public TileScript AssociatedTileScript { get; set; }

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