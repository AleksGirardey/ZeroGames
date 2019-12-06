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
    public Dog SelectedDog;

    public GameObject WarningScreen;

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
            GameObject day = Instantiate(prefabDay, Calendar.transform, true);
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
            SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
        }

        if (SelectedDog.TrainingsConfirmed == false)
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

        WarningScreen.SetActive(false);
        print("Trainings confirmed!");

        ConfirmedTrainings.Clear();
    }

    public void SetSelectedDog(Dog selected)
    {
        SelectedDog = selected;
        SelectedDogTxt.text = selected.dogName;
        SelectedDogImg.sprite = selected.avatar;
    }

    private void Update()
    {
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

    public void NextWeekButton()
    {
        foreach(StatsChien dog in GameManager.Instance.player.kennel.dogs)
        {
            if(dog.TrainingsConfirmed == false)
            {
                StopCoroutine("Warning");
                StartCoroutine("Warning");
                return;
            }
        }

        print("next week >>");
        

        foreach (StatsChien dog in GameManager.Instance.player.kennel.dogs)
        {
            dog.ClearTraining();
            dog.TrainingsConfirmed = false;
        }

        MenuManager.Instance.displayMenu.LoadScreen(MenuManager.Instance.displayMenu.trainingCanvasPrefab);

        /*
        BinScreen.SetActive(false);
        foreach (TrainingSlot trainingSlot in trainingSlots)
        {
            if(trainingSlot.actualTraining != null)
            {
                Destroy(trainingSlot.actualTraining.gameObject); // reset le calendrier
            }
            trainingSlot.energyBar.EnergyBarsAvailable = 3;
        }
        */

    }


    IEnumerator Warning()
    {
        WarningScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        WarningScreen.SetActive(false);
    }

}