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
        Results.transform.position = new Vector3((float)2.11, (float)5.94, 0);
        Results.SetActive(true);
        // TODO: wait for user to click
        Restart.transform.position = new Vector3((float)-0.081, (float)-3.403, 0);
        Restart.SetActive(true);
    }

    public void OnGameLoss()
    {
        Results.transform.position = new Vector3((float)2.11, (float)5.94, 0);
        Results.SetActive(true);
        // TODO: wait for user to click
        Restart.transform.position = new Vector3((float)-0.081, (float)-3.403, 0);
        Restart.SetActive(true);
    }

}
