using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool IsDug { get; set; }
    public bool IsMine { get; set; }
    public int AdjMines { get; set; }

    public virtual void Dig()
    {
        // TODO: emit an event based on whether it's a mine or not
    }

    public Tile(bool isMine)
    {
        IsMine = isMine;
        AdjMines = 0;
    }

    public virtual void IncrementAdjMines()
    {
        AdjMines++;
    }
}