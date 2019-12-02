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
            SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
        }
    }

    public void SetSelectedDog(Dog dog)
    {
        SelectedDog = dog;
        SelectedDogTxt.text = dog.dogName;
        SelectedDogImg.sprite = dog.avatar;
        SelectedDogMood.text = dog.Mood;
    }

 

}