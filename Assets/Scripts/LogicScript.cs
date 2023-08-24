using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicScript : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Intermediate,
        Expert,
    }
    public Difficulty CurDifficulty;
    public GameObject[] Tiles;
    public GameObject BoardPrefab;
    public BoardScript BoardScript;
    public Camera MainCamera;
    public UnityEvent InitialStart;
    public GameObject UIPrefab;
    public UnityEvent ActuallyStart;
    private UIScript UIScript;
    public int LRows { get; set; } = 0; // inefficient, but fine for now
    public int LCols { get; set; } = 0;
    public int LNumMines { get; set; } = 0;


    void Start()
    {
        GameObject instantiatedUI = GameObject.Instantiate(UIPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        InitialStart.Invoke(); // show full UI
        UIScript = instantiatedUI.GetComponent<UIScript>();
    }

    // EASY: 8 x 8, 10 mines
    // INTERMEDIATE: 16 x 16, 40 mines
    // EXPERT: 30 x 16, 99 mines
    // would probably make the most sense to hard code in coordinate placements for tiles based on difficulty
    // resize camera differently for each difficulty

    public void OnEasySelected()
    {
        CurDifficulty = Difficulty.Easy;
        LRows = 8;
        LCols = 8;
        LNumMines = 10;
        StartGame();

    }

    public void OnIntermediateSelected()
    {
        CurDifficulty = Difficulty.Intermediate;
        LRows = 16;
        LCols = 16;
        LNumMines = 40;
        StartGame();

    }

    public void OnExpertSelected()
    {
        CurDifficulty = Difficulty.Expert;
        LRows = 30;
        LCols = 16;
        LNumMines = 99;
        StartGame();
    }

    void Update()
    {

    }

    public void OnGameWon()
    {
        Debug.Log("You win!");
    }

    public void OnGameLoss()
    {
        Debug.Log("You lose :(");
    }

    public void OnGameRestart()
    {
        BoardScript.Clear();
        Destroy(BoardPrefab);
        StartGame();
    }

    void StartGame() // todo: add parameter of difficulty
    {
        GameObject instantiatedBoard = Instantiate(BoardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BoardScript = instantiatedBoard.GetComponent<BoardScript>();
        ActuallyStart.AddListener(BoardScript.OnActuallyStart);
        if (CurDifficulty == Difficulty.Easy)
        {

        }
        else if (CurDifficulty == Difficulty.Intermediate)
        {

        }
        else // expert
        {

        }
    }
}


