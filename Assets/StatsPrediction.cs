using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StatsPrediction : MonoBehaviour
{
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;

    public bool MaxSpeed;
    public bool Acceleration;
    public bool Stamina;
    public bool Mental;

    public float Change;
    public float StatsBefore;
    public float StatsAfter;



    public List<Training> TrainList = new List<Training>();

    // Start is called before the first frame update
    void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (MaxSpeed)
        {
            MaxSpeedSetUp();
            StatsBefore = trainingManager.SelectedDog.VitesseMax;
        }
        else if (Acceleration)
        {
            AccelerationSetUp();
            StatsBefore = trainingManager.SelectedDog.Acceleration;
        }
        else if (Stamina)
        {
            StaminaSetUp();
            StatsBefore = trainingManager.SelectedDog.Endurance;
        }
        /*else if (Mental)
        {
            MentalSetUp();
                    StatsBefore = trainingManager.SelectedDog.Mental;
        }*/
    }

    public void MaxSpeedSetUp()
    {
        TrainList = trainingManager.TrainingList;

        for (int i = 0; i < TrainList.Count; i++)
        {
            if ( TrainList[i].VitesseMaxDef != 0 || TrainList[i].VitesseMaxTempo != 0)
            {
                Change = Change + TrainList[i].VitesseMaxDef + TrainList[i].VitesseMaxTempo;
            }
        }

        StatsAfter = StatsBefore + Change;
        Letter(StatsAfter);
        Change = 0;
    }

    public void AccelerationSetUp()
    {
        TrainList = trainingManager.TrainingList;



        for (int i = 0; i < TrainList.Count; i++)
        {
            if (TrainList[i].AccelerationDef != 0 || TrainList[i].AccelerationTempo != 0)
            {
                Change = Change + TrainList[i].VitesseMaxDef + TrainList[i].VitesseMaxTempo;
            }
        }

        StatsAfter = StatsBefore + Change;
        Letter(StatsAfter);
        Change = 0;
    }

    public void StaminaSetUp()
    {
        TrainList = trainingManager.TrainingList;


        for (int i = 0; i < TrainList.Count; i++)
        {
            if (TrainList[i].EnduranceDef != 0 || TrainList[i].EnduranceTempo != 0)
            {
                Change = Change + TrainList[i].VitesseMaxDef + TrainList[i].VitesseMaxTempo;
            }
        }

        StatsAfter = StatsBefore + Change;
        Letter(StatsAfter);
        Change = 0;
    }

    /*void MentalSetUp()
    {
        TrainList = trainingManager.TrainingList;



        for (int i = 0; i < TrainList.Count; i++)
        {
            if (TrainList[i].VitesseMaxDef != 0 || TrainList[i].VitesseMaxTempo != 0)
            {
                Change = Change + TrainList[i].VitesseMaxDef + TrainList[i].VitesseMaxTempo;
            }
        }

        StatsAfter = StatsBefore + Change;
        Letter(StatsAfter);
        Change = 0;
    }*/


    void Letter(float StatsAfter)
    {
        if (StatsAfter < 250)
        {
            GetComponent<Text>().text = "C-";
        }
        else if (StatsAfter < 350)
        {
            GetComponent<Text>().text = "C";
        }
        else if (StatsAfter < 450)
        {
            GetComponent<Text>().text = "C+";
        }
        else if (StatsAfter < 550)
        {
            GetComponent<Text>().text = "B-";
        }
        else if (StatsAfter < 650)
        {
            GetComponent<Text>().text = "B";
        }
        else if (StatsAfter < 750)
        {
            GetComponent<Text>().text = "B+";
        }
        else if (StatsAfter < 850)
        {
            GetComponent<Text>().text = "A-";
        }
        else if (StatsAfter < 950)
        {
            GetComponent<Text>().text = "A";
        }
        else
        {
            GetComponent<Text>().text = "A+";
        }
    }
}
