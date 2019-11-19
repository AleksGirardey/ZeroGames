using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogData : MonoBehaviour
{
    public List<Color> KennelDogData = new List<Color>();
    public Color KennelDogA;
    public Color KennelDogB;
    public Color KennelDogC;
    public Color KennelDogD;
    public Color KennelDogE;


    private void Awake()
    {
        KennelDogData.Add(KennelDogA);
        KennelDogData.Add(KennelDogB);
        KennelDogData.Add(KennelDogC);
        KennelDogData.Add(KennelDogD);
        KennelDogData.Add(KennelDogE);
    }
}
