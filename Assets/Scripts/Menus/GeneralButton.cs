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

    public GameObject Highlight;

    public GameManager Test;
       

    public void ChangeScreen()
    {
        if (Kennel)
        {
            Kennel_canvas.gameObject.SetActive(true);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);

             Highlight.GetComponent<ButtonHighlight>().Kennel = true;
             Highlight.GetComponent<ButtonHighlight>().Management = false;
             Highlight.GetComponent<ButtonHighlight>().DogTrack = false;
             Highlight.GetComponent<ButtonHighlight>().Training = false;
             Highlight.GetComponent<ButtonHighlight>().ChangeScreen();
            
            
        }
        else if (Management)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(true);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);

            Highlight.GetComponent<ButtonHighlight>().Kennel = false;
            Highlight.GetComponent<ButtonHighlight>().Management = true;
            Highlight.GetComponent<ButtonHighlight>().DogTrack = false;
            Highlight.GetComponent<ButtonHighlight>().Training = false;
            Highlight.GetComponent<ButtonHighlight>().ChangeScreen();
           
        }
        else if (DogTrack)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(true);
            Training_canvas.gameObject.SetActive(false);

            Highlight.GetComponent<ButtonHighlight>().Kennel = false;
            Highlight.GetComponent<ButtonHighlight>().Management = false;
            Highlight.GetComponent<ButtonHighlight>().DogTrack = true;
            Highlight.GetComponent<ButtonHighlight>().Training = false;
            Highlight.GetComponent<ButtonHighlight>().ChangeScreen();
            
        }
        else
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(true);

            Highlight.GetComponent<ButtonHighlight>().Kennel = false;
            Highlight.GetComponent<ButtonHighlight>().Management = false;
            Highlight.GetComponent<ButtonHighlight>().DogTrack = false;
            Highlight.GetComponent<ButtonHighlight>().Training = true;
            Highlight.GetComponent<ButtonHighlight>().ChangeScreen();
            
        }

        //Test.PlayerDogs[0].Endurance
        
    }
}
