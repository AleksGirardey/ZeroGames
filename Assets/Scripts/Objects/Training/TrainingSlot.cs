using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum DayOfTraining {
    Monday = 0,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

public class TrainingSlot : MonoBehaviour, IDropHandler
{
    public DayOfTraining day;

    //public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;

    public Training training;
    [FormerlySerializedAs("EnergyBar")] public EnergyBars energyBar;

    public void Start() {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        energyBar = transform.parent.parent.GetComponentInChildren<EnergyBars>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null
            && training == null
            && energyBar.EnergyBarNb() != 0
            && eventData.pointerDrag.GetComponent<TrainingButton>() != null
            && energyBar.NextEnergyBarNb() != 0
            && energyBar.EnergyBarsAvailable - 1 >= energyBar.MinEnergy)
             {
            energyBar.UpdEnergy(energyBar.previousDay, 3 - energyBar.EnergyBarsAvailable);
            training = eventData.pointerDrag.GetComponent<TrainingButton>().Training;
            eventData.pointerDrag.transform.position = gameObject.transform.position - new Vector3(0, 55, 0);
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            eventData.pointerDrag.GetComponent<TrainingButton>().TrainingSlot = this;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
            eventData.pointerDrag.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
            //GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector3(0, 0, 0); UI incompréhensible, impossible de mettre 0,0,0 en position du TrainingButton


        }
    }




}
