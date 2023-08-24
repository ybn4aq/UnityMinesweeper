using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Logo;
    [SerializeField]
    private GameObject Difficulties;
    [SerializeField]
    private GameObject Quit;
    [SerializeField]
    private GameObject Results;
    [SerializeField]
    private GameObject Background;

    void Start()
    {
        Logo = GameObject.FindGameObjectWithTag("Logo");
        Difficulties = GameObject.FindGameObjectWithTag("Difficulties");
        Quit = GameObject.FindGameObjectWithTag("Quit");
        Results = GameObject.FindGameObjectWithTag("Results");
        Background = GameObject.FindGameObjectWithTag("Background");
        Results.SetActive(false);
    }

    void Update()
    {

    }

    public void OnInitialStart()
    {
        Logo.SetActive(false);
        Difficulties.SetActive(false); 
        Quit.SetActive(false);
        Results.SetActive(false);
        Background.SetActive(false);
    }

    public void OnHideUI()
    {
        Logo.SetActive(false);
        Difficulties.SetActive(false);
        Quit.SetActive(false);
        Results.SetActive(false);
        Background.SetActive(false);
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

    public void OnGameWon()
    {

    }

    public void OnGameLoss()
    {

    }

}
