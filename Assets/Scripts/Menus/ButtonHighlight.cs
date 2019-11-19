using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHighlight : MonoBehaviour
{
    public bool Kennel;
    public bool Management;
    public bool DogTrack;
    public bool Training;

    public GameObject Kennel_dots;
    public GameObject Management_dots;
    public GameObject DogTrack_dots;
    public GameObject Training_dots;

    public void ChangeScreen()
    {
        if (Kennel)
        {
            Kennel_dots.gameObject.SetActive(true);
            Management_dots.gameObject.SetActive(false);
            DogTrack_dots.gameObject.SetActive(false);
            Training_dots.gameObject.SetActive(false);            
        }
        else if (Management)
        {
            Kennel_dots.gameObject.SetActive(false);
            Management_dots.gameObject.SetActive(true);
            DogTrack_dots.gameObject.SetActive(false);
            Training_dots.gameObject.SetActive(false);       

        }
        else if (DogTrack)
        {
            Kennel_dots.gameObject.SetActive(false);
            Management_dots.gameObject.SetActive(false);
            DogTrack_dots.gameObject.SetActive(true);
            Training_dots.gameObject.SetActive(false);          

        }
        else
        {
            Kennel_dots.gameObject.SetActive(false);
            Management_dots.gameObject.SetActive(false);
            DogTrack_dots.gameObject.SetActive(false);
            Training_dots.gameObject.SetActive(true);          

        }
        


    }
}
