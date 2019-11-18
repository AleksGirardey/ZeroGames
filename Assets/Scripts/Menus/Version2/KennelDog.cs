using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KennelDog : MonoBehaviour
{
    public int _dog;

    public GameObject Archive;

    private void Start()
    {
        GetComponent<Image>().color = Archive.GetComponent<DogData>().KennelDogData[_dog];
    }


    public void ChangeDog()
    {
        if(_dog < 0)
        {
            _dog = Archive.GetComponent<DogData>().KennelDogData.Count - 1;
        }
        else if (_dog >= Archive.GetComponent<DogData>().KennelDogData.Count)
        {
            _dog = 0;
        }
        GetComponent<Image>().color = Archive.GetComponent<DogData>().KennelDogData[_dog];
    }
}
