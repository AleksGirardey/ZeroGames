using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TrainingDay : MonoBehaviour
{
    public DayOfTraining dayOfWeek;

    [FormerlySerializedAs("TrainingAssignation")] public GameObject trainingAssignation;
    public TrainingSlot prefabTrainingSlot;

    public List<TrainingSlot> trainingSlots;

    public List<TrainingSlot> SetTrainingSlots()
    {
        List<TrainingSlot> slots = new List<TrainingSlot>();
        GetComponentInChildren<Text>().text = dayOfWeek.ToString();

        for (int i = 0; i < 4; i++)
        {
            TrainingSlot obj = Instantiate(prefabTrainingSlot, trainingAssignation.transform, true);
            obj.GetComponent<TrainingSlot>().day = dayOfWeek;
            obj.transform.localScale = new Vector3(1,1,1);
            slots.Add(obj);
        }
        trainingSlots = slots;

        return slots;
    }
}
