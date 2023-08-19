using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BoardScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public Tile[,] board; // m x n
    public int rows; // m, height
    public int cols; // n, height
    public int numMines;
    private float curX;
    private float curY;
    private HashSet<(int, int)> mineCoords;
    public UnityEvent GameWon;
    public UnityEvent GameLoss;
    public UnityEvent GameRestart;
    public int minesFlagged { get; set; } = 0;
    public int blanksDug { get; set; } = 0;
    public int numBlanks { get; set; } = 0;
    public int flagsPlaced { get; set; } = 0;
    public Tile losingTile { get; set; }
    // EASY: 8 x 8, 10 mines
    // INTERMEDIATE: 16 x 16, 40 mines
    // EXPERT: 30 x 16, 99 mines
    // would probably make the most sense to hard code in coordinate placements for tiles based on difficulty
    // resize camera differently for each difficulty

    void Start()
    {
        StartGame();
        minesFlagged = 0;
        blanksDug = 0;
        flagsPlaced = 0;
        numBlanks = (rows * cols) - numMines;
        // TODO: add difficulties
    }

    void Update()
    {
        // TODO: listen for UnityEvent RestartGame
        if (minesFlagged == numMines && blanksDug == numBlanks)
        {
            GameWon.Invoke();
            // TODO: have GUI listen to this
            // TODO: have each tile be unable to be interacted with during game won
            // TODO: reveal mines
        }
        if (Input.GetKeyUp(KeyCode.Space)) // Debug: output key variables to console
        {
            Debug.Log("Mines Flagged: " + minesFlagged.ToString());
            Debug.Log("Blanks Dug: "+blanksDug.ToString());
            Debug.Log("Number of Blanks: " + numBlanks.ToString());
            Debug.Log("Flags Placed: "+flagsPlaced.ToString());
            Debug.Log("Number of mines: "+numMines.ToString());
        }
    }

    public void OnMineDug()
    {
        Debug.Log("OnMineDug fired");
        GameLoss.Invoke();
        // TODO: have GUI listen to this
        // TODO: have each tile be unable to be interacted with during game loss
        // TODO: reveal mines, including false positives
    }

    public void OnBlankDug()
    {
        Debug.Log("OnBlankDug fired");
        blanksDug++;
    }

    public void OnMineFlagged()
    {
        Debug.Log("OnMineFlagged fired");
        flagsPlaced++; // will be what the scoreboard displays
        minesFlagged++;
    }

    public void OnBlankFlagged()
    {
        Debug.Log("OnBlankFlagged fired");
        flagsPlaced++;
    }

    public void OnMineUnFlagged()
    {
        Debug.Log("OnMineUnFlagged fired");
        minesFlagged--;
        flagsPlaced--;
    }

    public void OnBlankUnFlagged()
    {
        Debug.Log("OnBlankUnFlagged fired");
        flagsPlaced--;
    }

    public void StartGame()
    {
        mineCoords = GetMineCoords();
        GenerateBoard();
        PopulateAdjTiles();
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

    private void ClearBoard()
    {
        Tile cur;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cur = board[i, j];
                Destroy(cur.AssociatedTileScript);
            }
        }
        board = null;
    }

    public void ClearGame()
    {
        ClearBoard();
        StartGame();
    }

    public void GenerateBoard()
    {
        Vector3 position;
        board = new Tile[rows, cols];
        (int, int) cur;
        curY = (float)2.5;
        for (int i = 0; i < rows; i++)
        {
            curX = (float) -1.5;
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
                    board[i,j] = associatedTile; // TODO: figure out whether or not to keep Tile[,] board
                    tileScript.AssociatedTile = associatedTile;
                    associatedTile.AssociatedTileScript = tileScript;
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
