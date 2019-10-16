using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_PopUp : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public GameObject PopUp;

    // Start is called before the first frame update
    void Start()
    {
        mat1 = GetComponent<MeshRenderer>().materials[1];
        mat2 = GetComponent<MeshRenderer>().materials[0];

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = mat1;        
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            PopUp.transform.position = new Vector3(transform.position.x, 0 , transform.position.z + 1.45f);
        }
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = mat2;
        
    }
}
