using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_Choice : MonoBehaviour
{
    public GameObject Training_PopUp;

    public int Number;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Training_PopUp.GetComponent<Training_Apply>().ChangeTraining(Number);
        }
    }
}
