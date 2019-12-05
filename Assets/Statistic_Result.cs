using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Statistic_Result : MonoBehaviour
{
    public StatsChien SelectedDog;

    public string DogName;

    public int WinAmount;
    public int LoseAmount;


    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        if (SelectedDog == null)
        {
            SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
        }



        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text  = DogName + " : " + WinAmount + " / " + LoseAmount;
    }

    public void SetSelectedDog(Dog dog)
    {
        SelectedDog = dog;
        DogName = dog.dogName;
        WinAmount = dog.NumberRaceWon;
        LoseAmount = dog.NumberRaceLost;
    }
}
