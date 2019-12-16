using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TrainingManager : MonoBehaviour {
    public GameObject prefabDay;
    [FormerlySerializedAs("Calendar")] public GameObject calendar;
    public GameObject dogListContainer;
    public GameObject dogButtonPrefab;
    
    private void FillDogListContainer() {
        Dog[] list = GameManager.Instance.player.kennel.dogs.ToArray();
        GameObject button;

        for (int i = 0; i < list.Length; i++) {
            button = Instantiate(dogButtonPrefab, dogListContainer.transform);
            button.transform.Find("DogName").GetComponent<Text>().text = list[i].dogName;
            button.transform.Find("DogImage").GetComponent<Image>().sprite = list[i].avatar;
            var i1 = i;
            button.GetComponent<Button>().onClick.AddListener(() => SetSelectedDog(list[i1]));
        }
    }

    public List<TrainingSlot> trainingSlots;

    [FormerlySerializedAs("SelectedDogTxt")] public Text selectedDogTxt;
    [FormerlySerializedAs("SelectedDogImg")] public Image selectedDogImg;
    [FormerlySerializedAs("SelectedDog")] public Dog selectedDog;

    [FormerlySerializedAs("WarningScreen")] public GameObject warningScreen;
    
    [FormerlySerializedAs("ConfirmedTrainings")] public List<Training> confirmedTrainings = new List<Training>();

    [FormerlySerializedAs("FreezeScreen")] public GameObject freezeScreen;
    [FormerlySerializedAs("BinScreen")] public GameObject binScreen;

    [FormerlySerializedAs("TrainingList")] public List<Training> trainingList;

    void Start() {
        EnergyBars previousDay = null;
        EnergyBars previousEnergyBar = null;

        foreach (DayOfTraining dot in Enum.GetValues(typeof(DayOfTraining))) {
            GameObject day = Instantiate(prefabDay, calendar.transform, true);
            day.transform.localScale = new Vector3(1, 1, 1);
            day.GetComponent<TrainingDay>().dayOfWeek = dot;
            trainingSlots.AddRange(day.GetComponent<TrainingDay>().SetTrainingSlots());
            day.GetComponentInChildren<EnergyBars>().previousDay = previousDay;
            previousDay = day.GetComponentInChildren<EnergyBars>();

            if(previousEnergyBar != null)
            {
                previousEnergyBar.nextDay = day.GetComponentInChildren<EnergyBars>();
            }
            
            previousEnergyBar = day.GetComponentInChildren<EnergyBars>();
        }
        
        FillDogListContainer();
        
        if(selectedDog == null)
        {
            SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
        }

        if (selectedDog.TrainingsConfirmed == false)
        {
            selectedDog.UpcomingTrainings.Clear();
        }

        foreach (StatsChien dog in GameManager.Instance.world.AllDogs)
        {
            if (!dog.trainingsCleared)
            {
                dog.EnduranceTempo.Clear();
                dog.VitesseMaxTempo.Clear();
                dog.AccelerationTempo.Clear();
                dog.EnduranceDef = 0;
                dog.VitesseMaxDef = 0;
                dog.AccelerationDef = 0;
                dog.trainingsCleared = true;
            }
        }
    }

    public void ConfirmTrainings() {
        int cost = confirmedTrainings.Count * 50;

        if (GameManager.Instance.player.money < cost) return;
        
        if (!selectedDog.TrainingsConfirmed)
        {
            foreach (TrainingSlot ts in trainingSlots)
            {
                if (ts.training != null) confirmedTrainings.Add(ts.training);
            }

            for (int i = 0; i < confirmedTrainings.Count; i++)
            {
                selectedDog.UpcomingTrainings.Add(confirmedTrainings[i]);
            }
            selectedDog.TrainingsConfirmed = true;
            selectedDog.AssignTrainings();
        }

        GameManager.Instance.player.money -= (confirmedTrainings.Count * 50);
        warningScreen.SetActive(false);
        print("Trainings confirmed!");

        confirmedTrainings.Clear();
    }

    public void SetSelectedDog(Dog selected)
    {
        selectedDog = selected;
        selectedDogTxt.text = selected.dogName;
        selectedDogImg.sprite = selected.avatar;
    }

    private void Update()
    {
        if (selectedDog.TrainingsConfirmed)
        {
            freezeScreen.SetActive(true);
        }
        else
        {
            freezeScreen.SetActive(false);
        }
        
    }


    public void SetBinScreen()
    {
        binScreen.SetActive(!binScreen.activeSelf);
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

        DateTime dateTime = DateTime.Parse(GameManager.Instance.date);

        dateTime = dateTime.AddDays(7);

        GameManager.Instance.date = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";

        foreach (Dog dog in GameManager.Instance.player.kennel.dogs)
        {
            dog.ClearTraining();
            dog.TrainingsConfirmed = false;
        }

        foreach (StatsChien dog in GameManager.Instance.world.AllDogs)
        {
            dog.RandomTraining();
        }

        MenuManager.Instance.displayMenu.LoadScreen(MenuManager.Instance.displayMenu.trainingCanvasPrefab);
    }


    IEnumerator Warning()
    {
        warningScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        warningScreen.SetActive(false);
    }

}