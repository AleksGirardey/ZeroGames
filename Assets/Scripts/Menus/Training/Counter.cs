using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public string Type;

    public int number;

    void Update()
    {
        GetComponent<Texte>().t.GetComponent<TextMesh>().text = Type + " = " + number;
    }
}
