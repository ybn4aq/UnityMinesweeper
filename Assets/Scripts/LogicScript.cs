using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Intermediate,
        Expert,
    }
    public GameObject[] Tiles;
    public GameObject boardPrefab;
    public BoardScript boardScript;
    void Start()
    {
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
        boardScript.Clear();
        Destroy(boardPrefab);
        StartGame();
    }

    void StartGame() // todo: add parameter of difficulty
    {
        GameObject instantiatedBoard = Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        boardScript = instantiatedBoard.GetComponent<BoardScript>();
    }
}


