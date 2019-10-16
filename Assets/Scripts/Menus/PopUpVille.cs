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
        transform.localScale = new Vector3(transform.localScale.x * 1.02f, transform.localScale.y, transform.localScale.z * 1.02f);
    }

    private void OnMouseOver()
    {

        /*if (Input.GetMouseButtonDown(0))
        {
            
        }*/
        
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x / 1.02f, transform.localScale.y, transform.localScale.z / 1.02f);
        GetComponent<MeshRenderer>().material = mat2;
    }
}
