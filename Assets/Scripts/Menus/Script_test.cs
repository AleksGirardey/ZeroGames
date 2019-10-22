using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_test : MonoBehaviour
{

    public Material mat1;
    public Material mat2;

    public GameObject fellowA;
    public GameObject fellowB;

    public GameObject Save;

    // Start is called before the first frame update
    void Start()
    {
        mat1 = GetComponent<MeshRenderer>().materials[1];
        mat2 = GetComponent<MeshRenderer>().materials[0];

        TEST = true;

        
    }

    private bool TEST;
    private void OnMouseOver()
    {        
        GetComponent<MeshRenderer>().material = mat1;
        if (Input.GetMouseButtonDown(0) && TEST)
        {
            StartCoroutine(ClickDeplacement()) ;
            TEST = false;
        }
    }

    private void OnMouseExit()
    {

        
        GetComponent<MeshRenderer>().material = mat2;
    }

    private IEnumerator ClickDeplacement()
    {
        for(int i = 0; i <=15; i += 1)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            fellowA.transform.position = new Vector3(fellowA.transform.position.x - 0.1f, fellowA.transform.position.y, fellowA.transform.position.z);
            fellowB.transform.position = new Vector3(fellowB.transform.position.x - 0.1f, fellowB.transform.position.y, fellowB.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        Save.SetActive(true) ;
        
    }
}
