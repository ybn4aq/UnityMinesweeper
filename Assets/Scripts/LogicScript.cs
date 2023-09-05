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
    [SerializeField]
    private GameObject MineCounterPrefab;
    public UnityEvent HideUI;
    [SerializeField]
    private GameObject TimerPrefab;
    [SerializeField]
    private GameObject SmileyPrefab;
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
        StartGame();
    }

    void StartGame()
    {
        HideUI.Invoke();
        GameObject smileyCheck = GameObject.FindGameObjectWithTag("Smiley");
        GameObject mineCounterCheck = GameObject.FindGameObjectWithTag("MineCounter");
        GameObject boardCheck = GameObject.FindGameObjectWithTag("Board"); // check to make sure board doesn't exist already
        GameObject timerCheck = GameObject.FindGameObjectWithTag("Timer");
        if (boardCheck != null) // if board already exists
        {
            boardCheck.GetComponent<BoardScript>().Clear();
            DestroyImmediate(boardCheck);
        }
        if (mineCounterCheck != null) // if mine counter already exists
        {
            DestroyImmediate(mineCounterCheck);
        }
        if (timerCheck != null) // if timer already exists
        {
            DestroyImmediate(timerCheck);
        }
        if (smileyCheck != null)
        {
            DestroyImmediate(smileyCheck);
        }
        GameObject instantiatedBoard = Instantiate(BoardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BoardScript = instantiatedBoard.GetComponent<BoardScript>();
        if (CurDifficulty == Difficulty.Easy)
        {
            GameObject instantiatedMineCounter = Instantiate(MineCounterPrefab, new Vector3(1.1f, 7.35f, 0), Quaternion.identity);
            GameObject instantiatedTimer = Instantiate(TimerPrefab, new Vector3(-5.45f, 7.35f, 0), Quaternion.identity);
            GameObject instantiatedSmiley = Instantiate(SmileyPrefab, new Vector3(-1.3f, 6.95f, 0), Quaternion.identity);

        }
        else if (CurDifficulty == Difficulty.Intermediate)
        {
            GameObject instantiatedMineCounter = Instantiate(MineCounterPrefab, new Vector3(5.15f, 9.35f, 0), Quaternion.identity);
            GameObject instantiatedTimer = Instantiate(TimerPrefab, new Vector3(-9.5f, 9.35f, 0), Quaternion.identity);
            GameObject instantiatedSmiley = Instantiate(SmileyPrefab, new Vector3(-1.5f, 9f, 0), Quaternion.identity);
        }
        else if (CurDifficulty == Difficulty.Expert)
        {
            GameObject instantiatedMineCounter = Instantiate(MineCounterPrefab, new Vector3(12.65f, 8.85f, 0), Quaternion.identity);
            GameObject instantiatedTimer = Instantiate(TimerPrefab, new Vector3(-16f, 8.85f, 0), Quaternion.identity);
            GameObject instantiatedSmiley = Instantiate(SmileyPrefab, new Vector3(-0.5f, 8.5f, 0), Quaternion.identity);
        }
    }
}


