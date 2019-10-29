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
        mat1 = GetComponent<MeshRenderer>().materials[1];  //Set up of the materials that will be used.
        mat2 = GetComponent<MeshRenderer>().materials[0];

    }


    public string SceneName;

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = mat1;  //Change the material to highlight the button.
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }

    private void OnMouseExit()
    {

        GetComponent<MeshRenderer>().material = mat2;  //Reset the material to the default one.
    }

   
}
