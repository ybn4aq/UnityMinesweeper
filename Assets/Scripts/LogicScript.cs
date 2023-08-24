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
    private GameObject UI;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI"); // TODO: make sure this works
        InitialStart.Invoke();




        StartGame(); // TODO: only start game when difficulty selection methods are invoked
    }

    public void OnEasySelected()
    {

    }

    public void OnIntermediateSelected()
    {

    }

    public void OnExpertSelected()
    {

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
    }
}


