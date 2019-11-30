using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DogButtonListKennel : MonoBehaviour
{
    public Image img; 
    public Text text; 
    private Dog _dog;
    [FormerlySerializedAs("KennelManager")] public KennelManager kennelManager;

    public void SetImg(Sprite dogSprite)
    {
        img.sprite = dogSprite;
    }

    public void SetName(string dogName)
    {
        text.text = dogName;
    }

    public void SetDog(Dog dog)
    {
        _dog = dog;
        img.sprite = dog.avatar;
        text.text = dog.dogName;
    }

    public void OnClick()
    {
        kennelManager.SetSelectedDog(_dog);
    }


}
