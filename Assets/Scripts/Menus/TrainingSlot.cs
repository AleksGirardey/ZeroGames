using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

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
            && eventData.pointerDrag.GetComponent<TrainingButton>() != null) {
            
            training = eventData.pointerDrag.GetComponent<TrainingButton>().Training;
            eventData.pointerDrag.transform.position = gameObject.transform.position - new Vector3(0, 55, 0);
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            eventData.pointerDrag.GetComponent<TrainingButton>().TrainingSlot = this;
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }




}
