using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
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

    }

    public void OnGameLoss()
    {

    }

    public void OnGameRestart()
    {
        Destroy(boardPrefab);   
    }

    void StartGame()
    {
        GameObject instantiatedBoard = Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BoardScript boardScript = instantiatedBoard.GetComponent<BoardScript>();
        boardScript.logic = this;
    }
}
