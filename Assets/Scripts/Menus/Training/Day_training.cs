using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_training : MonoBehaviour
{
    public GameObject Training_PopUp;
    public Material mat1;
    public Material mat2;

    public string day;

    public GameObject Exhaust_Manager;

    private int TrainingType;

    public GameObject ACounter;
    public GameObject BCounter;
    public GameObject CCounter;

    void Start()
    {
        mat1 = GetComponent<MeshRenderer>().materials[0];
        mat2 = GetComponent<MeshRenderer>().materials[1];
        

    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Training_PopUp.transform.position = new Vector3 (transform.position.x , transform.position.y + 0.01f , transform.position.z);
            Training_PopUp.SetActive(true);
            Training_PopUp.GetComponent<Training_Apply>().Day = this.gameObject;
            GetComponent<Texte>().t.gameObject.SetActive(false);
        }
    }


    public void Training_SetUp(int Number)
    {
        switch (Number)
        {
            case 1:
                GetComponent<Texte>().t.gameObject.SetActive(true);
                GetComponent<Texte>().t.GetComponent<TextMesh>().text = "Training A";                
                if(GetComponent<MeshRenderer>().material == mat1)
                {
                    exhaust_giver(day);
                }
                GetComponent<MeshRenderer>().material = mat2;
                TrainingType = 1;
                break;

            case 2:
                GetComponent<Texte>().t.gameObject.SetActive(true);
                GetComponent<Texte>().t.GetComponent<TextMesh>().text = "Training B";
                if (GetComponent<MeshRenderer>().material == mat1)
                {
                    exhaust_giver(day);
                }
                GetComponent<MeshRenderer>().material = mat2;
                TrainingType = 2;
                break;

            case 3:
                GetComponent<Texte>().t.gameObject.SetActive(true);
                GetComponent<Texte>().t.GetComponent<TextMesh>().text = "Training C";
                if (GetComponent<MeshRenderer>().material == mat1)
                {
                    exhaust_giver(day);
                }
                GetComponent<MeshRenderer>().material = mat2;
                TrainingType = 3;
                break;

            case 4:
                GetComponent<Texte>().t.gameObject.SetActive(true);
                GetComponent<Texte>().t.GetComponent<TextMesh>().text = "No Training";
                if (GetComponent<MeshRenderer>().material == mat2)
                {
                    exhaust_taker(day);
                }
                GetComponent<MeshRenderer>().material = mat1;
                TrainingType = 4;
                break;
        }
    }

    private void exhaust_giver(string day)
    {
        switch (day)
        {
            case "Monday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().mon += 1;
                break;
            case "Tuesday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().tue += 1;
                break;
            case "Wednesday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().wed += 1;
                break;
            case "Thursday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().thu += 1;
                break;
            case "Friday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().fri += 1;
                break;
        }
    }

    private void exhaust_taker(string day)
    {
        switch (day)
        {
            case "Monday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().mon -= 1;
                break;
            case "Tuesday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().tue -= 1;
                break;
            case "Wednesday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().wed -= 1;
                break;
            case "Thursday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().thu -= 1;
                break;
            case "Friday":
                Exhaust_Manager.GetComponent<Exhaust_Manager>().fri -= 1;
                break;
        }
    }

    public void NextWeek()
    {
        switch ( TrainingType)
        {
            case 1:
                ACounter.GetComponent<Counter>().number += 1;
                Training_SetUp(4);
                break;
            case 2:
                BCounter.GetComponent<Counter>().number += 1;
                Training_SetUp(4);
                break;
            case 3:
                CCounter.GetComponent<Counter>().number += 1;
                Training_SetUp(4);
                break;
            case 4:
                Training_SetUp(4);
                break;
        }
    }
}
