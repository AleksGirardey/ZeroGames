using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonMenus : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public int type;

    public GameObject chenil;

    public GameObject Management;
    public GameObject Chien;

    public GameObject Cynodrome;

    public GameObject Training;


    void Start()
    {
        mat1 = GetComponent<MeshRenderer>().materials[1];
        mat2 = GetComponent<MeshRenderer>().materials[0];
        // Get the material that the button will use.
    }


    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = mat1; //Change the color of the button when the mouse come over it, highlighting it for the player
        transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y, transform.localScale.z * 1.1f); //Increase the size to highlight even more.
    }

    private void OnMouseOver()
    {      
        
        if (Input.GetMouseButtonDown(0) && type == 0)  // Get the corresponding menu to the front of the screen.
        {
            chenil.transform.position = new Vector3(0, 0, 0);
            Management.transform.position = new Vector3(50, 50, 50);
            Chien.transform.position = new Vector3(50, 50, 50);
            Cynodrome.transform.position = new Vector3(-100, 100, 0);
            Training.transform.position = new Vector3(-100, -100, 0);
        }
        else if (Input.GetMouseButtonDown(0) && type == 1)
        {
            chenil.transform.position = new Vector3(100, 100, 0);
            Management.transform.position = new Vector3(0, 0, 0);
            Chien.transform.position = new Vector3(0, 0.1f, 0);
            Cynodrome.transform.position = new Vector3(-100, 100, 0);
            Training.transform.position = new Vector3(-100, -100, 0);
        }
        else if (Input.GetMouseButtonDown(0) && type == 2)
        {
            chenil.transform.position = new Vector3(100, 100, 0);
            Management.transform.position = new Vector3(100, -100, 0);
            Chien.transform.position = new Vector3(100, -100.1f, 0);
            Cynodrome.transform.position = new Vector3(0, 0, 0);
            Training.transform.position = new Vector3(-100, -100, 0);
        }
        else if (Input.GetMouseButtonDown(0) && type == 3)
        {
            chenil.transform.position = new Vector3(100, 100, 0);
            Management.transform.position = new Vector3(100, -100, 0);
            Chien.transform.position = new Vector3(0, 0.1f, 0);
            Cynodrome.transform.position = new Vector3(-100, 100, 0);
            Training.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x / 1.1f, transform.localScale.y, transform.localScale.z / 1.1f);  //Resume to the original size.
        GetComponent<MeshRenderer>().material = mat2;  // Get back to original material.
    }
}
