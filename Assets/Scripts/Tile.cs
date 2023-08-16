using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool isDug { get; set; }
    public bool isMine { get; set; }
    public int adjMines { get; set; }

    public virtual void Dig()
    {

    }

    public Tile(bool isMine)
    {
        this.isMine = isMine;
    }

    public virtual void IncrementAdjMines()
    {
        adjMines++;
    }
}