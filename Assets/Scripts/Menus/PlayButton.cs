using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
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

    private void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material = mat1;
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    private void OnMouseExit()
    {

        GetComponent<MeshRenderer>().material = mat2;
    }

   
}
