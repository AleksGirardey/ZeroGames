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
    public Text SelectedDogMood;

    void Start()
    {
        if (SelectedDog == null)
        {
            SetSelectedDog(GameManager.Instance.PlayerDogs[0]);
        }
    }

    public void SetSelectedDog(StatsChien Dog)
    {
        SelectedDog = Dog;
        SelectedDogTxt.text = Dog.Name;
        SelectedDogImg.sprite = Dog.dogSprite;
        SelectedDogMood.text = Dog.Mood;
    }

 

}