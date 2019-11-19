using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum DayOfTraining {
    MONDAY = 0,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY
}

public class TrainingSlot : MonoBehaviour, IDropHandler
{
    public DayOfTraining day;

    //public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    public TrainingManager TrainingManager;

    public Training training;
    public EnergyBars EnergyBar;

    public void Start() {
        TrainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        EnergyBar = transform.parent.parent.GetComponentInChildren<EnergyBars>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && training == null && EnergyBar.EnergyBarNb() != 0)
        {
            training = eventData.pointerDrag.GetComponent<TrainingButton>().Training;
            //eventData.pointerDrag.GetComponent<RectTransform>().transform.position = gameObject.transform.position;
            eventData.pointerDrag.transform.position = gameObject.transform.position - new Vector3(0, 55, 0);
             //eventData.pointerDrag.transform.position = gameObject.GetComponent<RectTransform>().position;
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            eventData.pointerDrag.GetComponent<TrainingButton>().TrainingSlot = this;
            eventData.pointerDrag.transform.SetParent(this.transform);


        }

        //print("Drop");

        /*
        if (eventData.pointerDrag != null)
        {
           
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;

            
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = gameObject.transform.position;
        }*/
    }




}
