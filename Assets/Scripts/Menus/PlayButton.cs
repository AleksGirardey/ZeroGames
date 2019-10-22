﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Material mat1;
    public Material mat2;


    // Start is called before the first frame update
    void Start() {
        mat1 = GetComponent<MeshRenderer>().materials[1];
        mat2 = GetComponent<MeshRenderer>().materials[0];
    }

    public string SceneName;

    private void OnMouseOver() {
        GetComponent<MeshRenderer>().material = mat1;
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }

    private void OnMouseExit() {
        GetComponent<MeshRenderer>().material = mat2;
    }
}
