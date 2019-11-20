using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class TrainingInventorySlot : MonoBehaviour, IDropHandler
{

    //public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;
    [FormerlySerializedAs("TrainingButton")] public TrainingButton trainingButton;


    public void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<TrainingButton>() != null)
        {
            
            if (eventData.pointerDrag.GetComponent<TrainingButton>().DefaultTrainingButton != null)
            {
                eventData.pointerDrag.GetComponent<TrainingButton>().DefaultTrainingButton.CloneSpawned = false;
            }
            Destroy(eventData.pointerDrag.GetComponent<GameObject>());
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = gameObject.transform.position;
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            eventData.pointerDrag.transform.SetParent(transform);

        }

    }

    

}
