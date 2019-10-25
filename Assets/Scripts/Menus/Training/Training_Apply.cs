using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_Apply : MonoBehaviour
{
    public GameObject Day;
    public string Test;

    public void ChangeTraining(int Number)
    {
        
        Day.GetComponent<Day_training>().Training_SetUp(Number);

        this.gameObject.SetActive(false);

    }

   
}
