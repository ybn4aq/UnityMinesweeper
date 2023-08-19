using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public GameObject boardPrefab;
    void Start()
    {
        GameObject instantiatedBoard = Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {   
        
    }
}
