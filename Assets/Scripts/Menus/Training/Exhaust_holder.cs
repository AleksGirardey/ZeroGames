using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust_holder : MonoBehaviour
{
    public Material[] colors;

    public GameObject A;
    public GameObject B;
    public GameObject C;

    public int energy;

    private void Start()
    {
        energy = 3;
    }

    private void Update()
    {
        if ( energy > 3)
        {
            energy = 3;
        }
        else if ( energy < 0)
        {
            energy = 0;
        }
        switch (energy)
        {
            case 3:
                A.GetComponent<MeshRenderer>().material = colors[1];
                B.GetComponent<MeshRenderer>().material = colors[1];
                C.GetComponent<MeshRenderer>().material = colors[1];
                break;
            case 2:
                A.GetComponent<MeshRenderer>().material = colors[2];
                B.GetComponent<MeshRenderer>().material = colors[2];
                C.GetComponent<MeshRenderer>().material = colors[0];
                break;
            case 1:
                A.GetComponent<MeshRenderer>().material = colors[3];
                B.GetComponent<MeshRenderer>().material = colors[0];
                C.GetComponent<MeshRenderer>().material = colors[0];
                break;
            case 0:
                A.GetComponent<MeshRenderer>().material = colors[0];
                B.GetComponent<MeshRenderer>().material = colors[0];
                C.GetComponent<MeshRenderer>().material = colors[0];
                break;
            default:
                A.GetComponent<MeshRenderer>().material = colors[0];
                B.GetComponent<MeshRenderer>().material = colors[0];
                C.GetComponent<MeshRenderer>().material = colors[0];
                break;

        }
    }

}
