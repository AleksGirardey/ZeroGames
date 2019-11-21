using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogButtonList : MonoBehaviour
{
    public Image img; // A REMPLACER PAR SPRITE
    //public Sprite dogSprite;
    public Text text; // NOM DU CHIEN
    private StatsChien Dog;
    public TrainingManager TrainingManager;

    public void Start()
    {
        //GetComponent<Button>().onClick += OnClick();
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
    }

    public void OnClick()
    {
        TrainingManager.SetSelectedDog(Dog);
    }


}
