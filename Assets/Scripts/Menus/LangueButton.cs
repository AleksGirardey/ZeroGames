using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangueButton : MonoBehaviour
{
    public GameObject TextManager;

    public string Langue;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextManager.GetComponent<TextManagement>().Langue = Langue;
        }
    }
}
