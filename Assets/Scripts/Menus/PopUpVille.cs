using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpVille : MonoBehaviour
{
    public Material mat1;
    public Material mat2;



    // Start is called before the first frame update
    void Start() 
    {
        mat1 = GetComponent<MeshRenderer>().materials[1];  // Set up the material that will be used.
        mat2 = GetComponent<MeshRenderer>().materials[0];

    }


    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = mat1; // Change the material and the size to highlight the button.
        transform.localScale = new Vector3(transform.localScale.x * 1.02f, transform.localScale.y, transform.localScale.z * 1.02f);
    }

    

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x / 1.02f, transform.localScale.y, transform.localScale.z / 1.02f);  //Return to the default size.
        GetComponent<MeshRenderer>().material = mat2;
    }
}
