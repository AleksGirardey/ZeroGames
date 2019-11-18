﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Texte : MonoBehaviour
{

    public string texte;

    public int FontSize;

    public TextMesh t;


    // Start is called before the first frame update
    void Start()
    {        

        

        GameObject text = new GameObject();
        text.transform.SetParent(this.transform);
        t = text.AddComponent<TextMesh>();
        
        t.text = texte;
        t.characterSize = 0.1f;
        t.anchor = TextAnchor.MiddleCenter;
        t.fontSize = FontSize;

        t.transform.localPosition = new Vector3(0, 0, 0);

        t.transform.localRotation = new Quaternion (0, 0, 0, 0);

        t.transform.localScale = new Vector3(1/transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
    }

  

    /*private void OnMouseEnter()
    {
        t.GetComponent<TextMesh>().characterSize += 0.1f; // Test of changing the text.
    }*/


}




