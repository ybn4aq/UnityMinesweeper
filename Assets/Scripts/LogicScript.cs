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
    public UnityEvent HideUI;
    public int LRows { get; set; } = 0; // inefficient, but fine for now
    public int LCols { get; set; } = 0;
    public int LNumMines { get; set; } = 0;


    void Start()
    {
        GameObject instantiatedUI = GameObject.Instantiate(UIPrefab, new Vector3(-4, (float)-0.5, 0), Quaternion.identity);
        InitialStart.Invoke(); // show full UI
        UIScript = instantiatedUI.GetComponent<UIScript>();
        HideUI.AddListener(UIScript.OnHideUI);
    }

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
        LRows = 16;
        LCols = 30;
        LNumMines = 99;
        StartGame();
    }

    void Update()
    {

    }

    public void OnGameRestart()
    {
        BoardScript.Clear();
        Destroy(BoardPrefab);
        StartGame();
    }

    void StartGame() // todo: add parameter of difficulty
    {
        GameObject boardCheck = GameObject.FindGameObjectWithTag("Board"); // check to make sure board doesn't exist already
        if (boardCheck != null) // if board already exists
        {
            boardCheck.GetComponent<BoardScript>().Clear();
            DestroyImmediate(boardCheck);
        }
        GameObject instantiatedBoard = Instantiate(BoardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BoardScript = instantiatedBoard.GetComponent<BoardScript>();
    }
}


