using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class BoardScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public Tile[,] board;
    public int rows;
    public int cols;
    public int numMines;
    private HashSet<(int, int)> mineCoords;
    public UnityEvent GameWon;
    public UnityEvent GameLoss;
    public int MinesFlagged { get; set; } = 0;
    public int BlanksDug { get; set; } = 0;
    public int NumBlanks { get; set; } = 0;
    public int FlagsPlaced { get; set; } = 0;
    public LogicScript Logic { get; set; }
    private UIScript UIScript;
    private bool IsStarted { get; set; } = false;
    private bool FirstCycle { get; set; } = false;

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rows = Logic.LRows;
        cols = Logic.LCols;
        numMines = Logic.LNumMines;
        UIScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        GameLoss.AddListener(UIScript.OnGameLoss);
        GameWon.AddListener(UIScript.OnGameWon);
        MinesFlagged = 0;
        BlanksDug = 0;
        FlagsPlaced = 0;
        NumBlanks = (rows * cols) - numMines;
        mineCoords = GetMineCoords();
        GenerateBoard();
        PopulateAdjTiles();
        // adding listeners to each tile
        Tile cur;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = board[i, j];
                GameWon.AddListener(cur.AssociatedTileScript.OnGameWon);
                GameLoss.AddListener(cur.AssociatedTileScript.OnGameLoss);
            }
        }
    }

    void Update()
    {
        if (MinesFlagged == numMines && BlanksDug == NumBlanks)
        {
            GameWon.Invoke();
        }
    }

    public void OnMineDug()
    {
        GameLoss.Invoke();
    }

    public void OnBlankDug()
    {
        // Debug.Log($"{name} ({GetInstanceID()}) reacted to an event.");
        BlanksDug++;
    }

    public void OnMineFlagged()
    {
        FlagsPlaced++; // will be what the scoreboard displays
        MinesFlagged++;
    }

    public void OnBlankFlagged()
    {
        FlagsPlaced++;
    }

    public void OnMineUnFlagged()
    {
        MinesFlagged--;
        FlagsPlaced--;
    }

    public void OnBlankUnFlagged()
    {
        FlagsPlaced--;
    }

    public void Clear()
    {
        GameObject[] toDelete;
        toDelete = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0 ; i < toDelete.Length; i++)
        {
            DestroyImmediate(toDelete[i]);
        }
    }

    private HashSet<(int, int)> GetMineCoords()
    {
        System.Random ran = new System.Random();
        int rRow;
        int rCol;
        HashSet<(int,int)> cache = new HashSet<(int,int)>();
        while (cache.Count != numMines)
        {
            rRow = ran.Next(0, rows - 1);
            rCol = ran.Next(0, cols - 1);
            if (!cache.Contains((rRow, rCol)))
            {
                cache.Add((rRow, rCol));
            }
        }
        return cache;
    }

    public void GenerateBoard()
    {
        float newXRow;
        float curX;
        float curY;
        Vector3 position;
        board = new Tile[rows, cols];
        (int, int) cur;
        if (Logic.CurDifficulty == LogicScript.Difficulty.Easy)
        {
            curY = (float)6;
            newXRow = (float)-5;
        }
        else if (Logic.CurDifficulty ==LogicScript.Difficulty.Intermediate)
        {
            curY = (float)8;
            newXRow = (float)-9;
        }
        else // expert
        {
            curY = (float)7.5;
            newXRow = (float)-15.5;
        }
        for (int i = 0; i < rows; i++)
        {
            curX = newXRow;
            for (int j = 0; j < cols; j++)
            {
                position = new Vector3(curX, curY, 0);
                cur = (i, j);
                bool isMine = mineCoords.Contains(cur);
                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                TileScript tileScript = tileObject.GetComponent<TileScript>();
                if (tileScript != null)
                {
                    Tile associatedTile = new Tile(isMine);
                    board[i,j] = associatedTile;
                    tileScript.AssociatedTile = associatedTile;
                    associatedTile.AssociatedTileScript = tileScript;
                    tileScript.boardScript = this;
                }
                curX += 1;
            }
            curY -= 1;
        }
    }

    private void PopulateAdjTiles()
    {
        Tile cur;
        List<Tile> adjTiles;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = board[i, j];
                if (cur.IsMine)
                {
                    continue;
                }
                adjTiles = GetAdjTiles(i, j);
                cur.AdjacentTiles = adjTiles; // Populating List<Tile> AdjacentTiles field for each Tile
                for (int k = 0; k < adjTiles.Count; k++)
                {
                    if (adjTiles[k].IsMine)
                    {
                        cur.IncrementAdjMines();
                    }
                }
            }
        }
    }
    private List<Tile> GetAdjTiles(int row, int col)
    {
        int r;
        int c;
        List<Tile> ret = new List<Tile>();
        List<(int, int)> compassDirections = new List<(int, int)>();
        (int, int) upLeft = (row - 1, col - 1);
        (int, int) upUp = (row, col - 1);
        (int, int) upRight = (row + 1, col - 1);
        (int, int) left = (row - 1, col);
        (int, int) right = (row + 1, col);
        (int, int) downLeft = (row - 1, col + 1);
        (int, int) downDown = (row, col + 1);
        (int, int) downRight = (row + 1, col + 1);
        compassDirections.Add(upLeft);
        compassDirections.Add(upUp);
        compassDirections.Add(upRight);
        compassDirections.Add(downLeft);
        compassDirections.Add(downRight);
        compassDirections.Add(left);
        compassDirections.Add(right);
        compassDirections.Add(downDown);
        for (int i = 0; i < compassDirections.Count; i++)
        {
            r = compassDirections[i].Item1;
            c = compassDirections[i].Item2;
            if (IsValidIdx((r, c)))
            {
                ret.Add(board[r, c]);
            }
        }
        return ret;
    }

    private bool IsValidIdx((int,int) coords)
    {
        int r = coords.Item1;
        int c = coords.Item2;
        return r >= 0 && c >= 0 && r < rows && c < cols;
    }

    public void PrintBoard()
    {
        Tile cur;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = board[i,j];
                if (cur.IsMine)
                {
                    Debug.Log("Mine");
                }
                else
                {
                    Debug.Log(cur.AdjMines);
                }
            }
        }
    }
}
