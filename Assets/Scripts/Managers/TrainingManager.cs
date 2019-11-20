using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingManager : MonoBehaviour
{
    public GameObject prefabDay;
    public GameObject Calendar;

    public List<TrainingSlot> trainingSlots;

    public Text SelectedDogTxt;
    public Image SelectedDogImg;
    public StatsChien SelectedDog;
    //public Color RedEnergy, OrangeEnergy, GreenEnergy, EmptyEnergy;

    public List<Training> ConfirmedTrainings = new List<Training>();
    //public int Monday, Tuesday, Wednesday, Thursday, Friday;
    //public int MondayEnergy, TuesdayEnergy, WednesdayEnergy, ThursdayEnergy, FridayEnergy;

    //public Image[] MondayEnergyImg, TuesdayEnergyImg, WednesdayEnergyImg, ThursdayEnergyImg, FridayEnergyImg;

    // Start is called before the first frame update

    public GameObject FreezeScreen, BinScreen;

    void Start()
    {
        EnergyBars previousDay = null;
        EnergyBars nextDay = null;
        EnergyBars previousEnergyBar = null;

        foreach (DayOfTraining dot in Enum.GetValues(typeof(DayOfTraining))) {
            GameObject day = Instantiate<GameObject>(prefabDay);
            day.transform.SetParent(Calendar.transform);
            day.transform.localScale = new Vector3(1, 1, 1);
            day.GetComponent<TrainingDay>().dayOfWeek = dot;
            trainingSlots.AddRange(day.GetComponent<TrainingDay>().SetTrainingSlots());


            day.GetComponentInChildren<EnergyBars>().previousDay = previousDay;
            previousDay = day.GetComponentInChildren<EnergyBars>();

            

            //day.GetComponentInChildren<EnergyBars>().nextDay = previousDay;
            //previousDay = day.GetComponentInChildren<EnergyBars>();
            if(previousEnergyBar != null)
            {
                previousEnergyBar.nextDay = day.GetComponentInChildren<EnergyBars>();
            }
            
            previousEnergyBar = day.GetComponentInChildren<EnergyBars>();
        }
        
        if(SelectedDog == null)
        {
            // RECUPERER LE PRMIER CHIEN DANS LES ASSETS
            // EN ATTENDANT JE LAI MIS DANS L'INSPECTEUR (1er  chien par defaut)
        }
        SetSelectedDog(SelectedDog);

       if(SelectedDog.TrainingsConfirmed == false)
        {
            SelectedDog.UpcomingTrainings.Clear();
        }
    }

    public void ConfirmTrainings()
    {
        
        if (!SelectedDog.TrainingsConfirmed)
        {
            foreach (TrainingSlot ts in trainingSlots)
            {
                if (ts.training != null) ConfirmedTrainings.Add(ts.training);
            }

            for (int i = 0; i < ConfirmedTrainings.Count; i++)
            {
                SelectedDog.UpcomingTrainings.Add(ConfirmedTrainings[i]);
            }
            SelectedDog.TrainingsConfirmed = true;
            SelectedDog.AssignTrainings();
        }


        print("Trainings confirmed!");
    }

    public void SetSelectedDog(StatsChien Dog)
    {
        SelectedDog = Dog;
        SelectedDogTxt.text = Dog.Name;
        SelectedDogImg.color = Dog.imgColor;
    }

    private void Update()
    {
        //jsp
        if (SelectedDog.TrainingsConfirmed)
        {
            FreezeScreen.SetActive(true);
        }
        else
        {
            FreezeScreen.SetActive(false);
        }
        
    }


    public void SetBinScreen()
    {
        BinScreen.SetActive(!BinScreen.activeSelf);
    }

}
