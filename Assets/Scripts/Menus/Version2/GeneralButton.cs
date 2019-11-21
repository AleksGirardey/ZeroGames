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

    public Camera Cam;

    public GameObject IIIdTarget;


    public void ChangeScreen()
    {
        Cam.GetComponent<MenuMovement>().Target = IIIdTarget.transform;
        if (Kennel)
        {
            Kennel_canvas.gameObject.SetActive(true);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);

            Highlight.GetComponent<Highlight_change>()._Kennel = true;
            Highlight.GetComponent<Highlight_change>().Change();
        }
        else if (Management)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(true);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(false);

            Highlight.GetComponent<Highlight_change>()._Management = true;
            Highlight.GetComponent<Highlight_change>().Change();

        }
        else if (DogTrack)
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(true);
            Training_canvas.gameObject.SetActive(false);

            Highlight.GetComponent<Highlight_change>()._DogTrack = true;
            Highlight.GetComponent<Highlight_change>().Change();
        }
        else
        {
            Kennel_canvas.gameObject.SetActive(false);
            Management_canvas.gameObject.SetActive(false);
            DogTrack_canvas.gameObject.SetActive(false);
            Training_canvas.gameObject.SetActive(true);

            Highlight.GetComponent<Highlight_change>()._Training = true;
            Highlight.GetComponent<Highlight_change>().Change();
        }
    }
}
