using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennelArrows : MonoBehaviour
{

    public bool way;

    public int _way;

    public GameObject TopDog;
    public GameObject MiddleDog;
    public GameObject BottomDog;


    private void Awake()
    {
        if (way)
        {
            _way = 1;
        }
        else
        {
            _way = -1;
        }
    }

    public void OnClick()
    {
        TopDog.GetComponent<KennelDog>()._dog += _way;
        TopDog.GetComponent<KennelDog>().ChangeDog();
        MiddleDog.GetComponent<KennelDog>()._dog += _way;
        MiddleDog.GetComponent<KennelDog>().ChangeDog();
        BottomDog.GetComponent<KennelDog>()._dog += _way;
        BottomDog.GetComponent<KennelDog>().ChangeDog();
    }


}
