using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private GameObject Logo;
    private GameObject Difficulties;
    private GameObject Quit;
    private GameObject Results;
    private GameObject Background;
    private GameObject Restart;

    void Start()
    {
        Logo = GameObject.FindGameObjectWithTag("Logo");
        Difficulties = GameObject.FindGameObjectWithTag("Difficulties");
        Quit = GameObject.FindGameObjectWithTag("Quit");
        Results = GameObject.FindGameObjectWithTag("Results");
        Background = GameObject.FindGameObjectWithTag("Background");
        Restart = GameObject.FindGameObjectWithTag("Restart");
        Results.SetActive(false);
        Restart.SetActive(false);
    }

    void Update()
    {

    }

    public void OnHideUI()
    {
        Logo.SetActive(false);
        Difficulties.SetActive(false);
        Quit.SetActive(false);
        Results.SetActive(false);
        Background.SetActive(false);
    }

    public void OnShowDifficulties()
    {
        Difficulties.SetActive(true);
        Restart.SetActive(false);
    }

    public void OnEasySelected()
    {
        OnHideUI();
    }

    public void OnIntermediateSelected()
    {
        OnHideUI();
    }

    public void OnExpertSelected()
    {
        OnHideUI();
    }

    public void OnGameWon()
    {
        Results.SetActive(true);
        Results.GetComponent<ResultsScript>().ChangeSprite(ResultsScript.SpriteType.Win);
        Restart.SetActive(true);
    }

    public void OnGameLoss()
    {
        Results.SetActive(true);
        Results.GetComponent<ResultsScript>().ChangeSprite(ResultsScript.SpriteType.Lose);
        Restart.SetActive(true);
    }

}
