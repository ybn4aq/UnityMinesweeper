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
   

    void Start()
    {
        GameObject instantiatedUI = GameObject.Instantiate(UIPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        InitialStart.Invoke(); // show full UI

        StartGame(); // TODO: only start game when difficulty selection methods are invoked
    }

    public void OnEasySelected()
    {
        CurDifficulty = Difficulty.Easy;
        StartGame();

    }

    public void OnIntermediateSelected()
    {
        CurDifficulty = Difficulty.Intermediate;
        StartGame();

    }

    public void OnExpertSelected()
    {
        CurDifficulty = Difficulty.Expert;
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


