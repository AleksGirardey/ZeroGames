using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogButtonListKennel : MonoBehaviour
{
    public Image img; 
    public Text text; 
    private StatsChien Dog;
    public KennelManager KennelManager;

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
        KennelManager.SetSelectedDog(Dog);
    }


}
