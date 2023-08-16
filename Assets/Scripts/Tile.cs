using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private bool isMined { get; set; }
    public int adjMines { get; set; }

    public virtual void Dig()
    {

    }

    public Tile()
    {
        isMined = false;
    }

    public virtual void IncrementAdjMines()
    {

    }

    internal void set()
    {
        throw new NotImplementedException();
    }
}

public class Mine : Tile
{
    public override void Dig()
    {
        base.Dig();
        // TODO: call method to end game, possibly emit signal
    }
}

public class Blank : Tile
{
    public override void Dig()
    {
        base.Dig();
    }


    public Blank()
    {
        adjMines = 0;
    }
    
    public override void IncrementAdjMines()
    {
        adjMines++;
    }
}
