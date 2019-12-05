using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KennelManager : MonoBehaviour
{
    public Text SelectedDogTxt;
    public Image SelectedDogImg;
    public StatsChien SelectedDog;
    public LocalizedText SelectedDogNatureKey;
    public LocalizedText SelectedDogDescriptionKey;
    public DogHistory SelectedDogHistory;

    void Start()
    {
        if (SelectedDog == null)
        {
            SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
        }
    }

    public void SetSelectedDog(Dog dog)
    {
        SelectedDog = dog;
        SelectedDogTxt.text = dog.dogName;
        SelectedDogImg.sprite = dog.avatar;
        SelectedDogNatureKey.key = dog.NatureKey;
        SelectedDogDescriptionKey.key = dog.DescriptionKey;
        SelectedDogHistory.RaceWon = dog.NumberRaceWon;
        SelectedDogHistory.MaxSpeedRun = dog.MaxSpeedRun;
        SelectedDogHistory.MoneyEarned = dog.MoneyEarned;
    }

 

}