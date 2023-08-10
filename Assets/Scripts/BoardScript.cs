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
    }

    void Update()
    {
        
    }

    HashSet<(int, int)> GetMineCoords() // This works
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

    void PrintList<T>(List<T> arr) // TODO: update for hashset
    {
        for (int i = 0; i < arr.Count; i++)
        {
            Debug.Log(arr[i]);
        }
    }

    void GenerateBoard()
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


    void PopulateAdjTiles()
    {
        // TODO: go through board and make each Blank have the correct amount of adj tiles
    }
}
