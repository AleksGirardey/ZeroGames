using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralButton : MonoBehaviour
{
    public bool Kennel;
    public bool Management;
    public bool DogTrack;
    public bool Training;

    public Canvas Kennel_canvas;
    public Canvas Management_canvas;
    public Canvas DogTrack_canvas;
    public Canvas Training_canvas; 


    public void ChangeScreen()
    {
        if (Kennel)
        {
            Kennel_canvas.gameObject.SetActive(true);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);
        }
        else if (Management)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(true);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);
        }
        else if (DogTrack)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(true);
            Training_canvas.gameObject.SetActive(false);
        }
        else
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(true);
        }
    }
}
