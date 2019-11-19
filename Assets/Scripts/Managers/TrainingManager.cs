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
    public Color RedEnergy, OrangeEnergy, GreenEnergy, EmptyEnergy;

    public List<Training> UpcomingTrainings = new List<Training>();
    public int Monday, Tuesday, Wednesday, Thursday, Friday;
    public int MondayEnergy, TuesdayEnergy, WednesdayEnergy, ThursdayEnergy, FridayEnergy;

    public Image[] MondayEnergyImg, TuesdayEnergyImg, WednesdayEnergyImg, ThursdayEnergyImg, FridayEnergyImg;

    // Start is called before the first frame update
    void Start()
    {
        EnergyBars previousDay = null;

        foreach (DayOfTraining dot in Enum.GetValues(typeof(DayOfTraining))) {
            GameObject day = Instantiate<GameObject>(prefabDay);
            day.transform.SetParent(Calendar.transform);
            day.transform.localScale = new Vector3(1, 1, 1);
            day.GetComponent<TrainingDay>().dayOfWeek = dot;
            trainingSlots.AddRange(day.GetComponent<TrainingDay>().SetTrainingSlots());
            day.GetComponentInChildren<EnergyBars>().previousDay = previousDay;
            previousDay = day.GetComponentInChildren<EnergyBars>().previousDay;
        }
        /*
        if(SelectedDog == null)
        {
            // RECUPERER LE PRMIER CHIEN DANS LES ASSETS
            // EN ATTENDANT JE LAI MIS DANS L'INSPECTEUR (1er  chien par defaut)
        }
        SetSelectedDog(SelectedDog);

        foreach(Image img in MondayEnergyImg)
        {
            img.color = GreenEnergy;
        }
        foreach (Image img in TuesdayEnergyImg)
        {
            img.color = GreenEnergy;
        }
        foreach (Image img in WednesdayEnergyImg)
        {
            img.color = GreenEnergy;
        }
        foreach (Image img in ThursdayEnergyImg)
        {
            img.color = GreenEnergy;
        }
        foreach (Image img in FridayEnergyImg)
        {
            img.color = GreenEnergy;
        }*/
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

        
    }

}
