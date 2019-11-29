﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogButtonList : MonoBehaviour
{
    public Image img; 
    public Text text;
    private StatsChien Dog;
    public TrainingManager TrainingManager;

    public void Start()
    {
        TrainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
    }

    public void SetImg(Sprite dogSprite)
    {
        img.sprite = dogSprite;
    }

    public void SetName(string dogName)
    {
        text.text = dogName;
    }

    public void SetDog(StatsChien dog)
    {
        Dog = dog;
        img.sprite = dog.dogSprite;
        text.text = dog.Name;
    }

    public void OnClick()
    {
        TrainingManager.SetSelectedDog(Dog);
    }


}
