using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeRaceManager : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject BeforeRacePopupA, BeforeRacePopupB, BeforeRacePopupC;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeforeRacePopUpA()
    {
        BeforeRacePopupA.SetActive(true);
        BeforeRacePopupB.SetActive(false);
        BeforeRacePopupC.SetActive(false);
    }

    public void BeforeRacePopUpB()
    {
        BeforeRacePopupA.SetActive(false);
        BeforeRacePopupB.SetActive(true);
        BeforeRacePopupC.SetActive(false);
    }

    public void BeforeRacePopUpC()
    {
        BeforeRacePopupA.SetActive(false);
        BeforeRacePopupB.SetActive(false);
        BeforeRacePopupC.SetActive(true);
    }

    public void StartRace(int laps) {
        GameManager.turns = laps;
        MenuManager.Instance.LoadMenu("RaceMenu");
    }
}
