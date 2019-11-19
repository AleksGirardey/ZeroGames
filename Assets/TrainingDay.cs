using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingDay : MonoBehaviour
{
    public DayOfTraining dayOfWeek;

    public GameObject TrainingAssignation;
    public TrainingSlot prefabTrainingSlot;

    public List<TrainingSlot> trainingSlots;

    public List<TrainingSlot> SetTrainingSlots()
    {
        List<TrainingSlot> trainingSlots = new List<TrainingSlot>();
        GetComponentInChildren<Text>().text = dayOfWeek.ToString();

        for (int i = 0; i < 4; i++)
        {
            TrainingSlot obj = Instantiate<TrainingSlot>(prefabTrainingSlot);
            obj.transform.SetParent(TrainingAssignation.transform);
            obj.GetComponent<TrainingSlot>().day = dayOfWeek;
            obj.transform.localScale = new Vector3(1,1,1);
            trainingSlots.Add(obj);
        }
        this.trainingSlots = trainingSlots;

        return trainingSlots;
    }
}
