using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_change : MonoBehaviour
{
    public bool _Kennel;
    public bool _Management;
    public bool _DogTrack;
    public bool _Training;


    public GameObject Kennel;
    public GameObject Management;
    public GameObject DogTrack;
    public GameObject Training;

    public void Change()
    {
        if (_Kennel)
        {
            Kennel.SetActive(true);
            Management.SetActive(false);
            DogTrack.SetActive(false);
            Training.SetActive(false);
            _Kennel = false;
        }
        else if (_Management)
        {
            Kennel.SetActive(false);
            Management.SetActive(true);
            DogTrack.SetActive(false);
            Training.SetActive(false);
            _Management = false;
        }
        else if (_DogTrack)
        {
            Kennel.SetActive(false);
            Management.SetActive(false);
            DogTrack.SetActive(true);
            Training.SetActive(false);
            _DogTrack = false;
        }
        else if (_Training)
        {
            Kennel.SetActive(false);
            Management.SetActive(false);
            DogTrack.SetActive(false);
            Training.SetActive(true);
            _Training = false;
        }
    }
}
