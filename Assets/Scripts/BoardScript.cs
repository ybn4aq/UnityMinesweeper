using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public Tile[,] board; // m x n
    public int rows; // m, height
    public int cols; // n, height
    public int numMines;
    public HashSet<(int, int)> mineCoords;
  
    void Start()
    {
        mineCoords = GetMineCoords();
        // PrintList<(int, int)>(mineCoords);
        GenerateBoard();
        PopulateAdjTiles();
        PrintBoard();
    }

    void Update()
    {
        
    }

    private HashSet<(int, int)> GetMineCoords() // This works
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

    private void PrintList<T>(List<T> arr) // TODO: update for hashset
    {
        for (int i = 0; i < arr.Count; i++)
        {
            Debug.Log(arr[i]);
        }
    }

    private void GenerateBoard()
    {
        (int, int) cur;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = (i, j);
                if (mineCoords.Contains(cur))
                {
                    board[i, j] = new Mine();
                }
                else
                {
                    board[i, j] = new Blank();
                }
            }
        }
    }


    private void PopulateAdjTiles()
    {
        Tile cur;
        List<Tile> adjTiles;
        // TODO: go through board and make each Blank have the correct amount of adj tiles
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = board[i, j];
                if (cur is Mine)
                {
                    continue;
                }
                adjTiles = GetAdjTiles(i, j);
                for (int k = 0; k < adjTiles.Count; k++)
                {
                    if (adjTiles[k] is Mine)
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
                if (cur is Mine)
                {
                    Debug.Log("Mine");
                }
                else
                {
                    Debug.Log(cur.adjMines);
                }
            }
        }
    }
}
