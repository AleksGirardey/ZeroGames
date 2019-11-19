using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollListAvailableTrainings : MonoBehaviour
{
    public GameObject buttonPrefab;
    private GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < GameManager.Trainings.Count; i++) // INSTANTIATE DES TRAININGS DANS AVAILABLE TRAININGS
        {
            GameObject TrainingInventorySlot = Instantiate(buttonPrefab) as GameObject;
            TrainingInventorySlot.SetActive(true);
            TrainingInventorySlot.GetComponentInChildren<TrainingButton>().Training = GameManager.Trainings[i];
            TrainingInventorySlot.transform.SetParent(buttonPrefab.transform.parent, false);
            TrainingInventorySlot.GetComponentInChildren<TrainingButton>().SetName(GameManager.Trainings[i].name);
        }

    }

    void CreateButtons()
    {

    }

}