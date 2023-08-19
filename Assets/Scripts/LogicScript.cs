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
        Destroy(boardPrefab);
        StartGame();
    }

    void StartGame() // todo: add parameter of difficulty
    {
        GameObject instantiatedBoard = Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BoardScript boardScript = instantiatedBoard.GetComponent<BoardScript>();
        boardScript.Logic = this;
        // TODO: delete below because it's unnecessary, but it was a good realization to make
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in Tiles)
        {
            if (tile != null)
            {

            }
        }
    }
}
