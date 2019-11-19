using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TrainingInventorySlot : MonoBehaviour, IDropHandler
{

    //public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    public TrainingManager TrainingManager;
    public TrainingButton TrainingButton;


    public void Start()
    {
        TrainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = gameObject.transform.position;
            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            //eventData.pointerDrag.GetComponent<TrainingButton>().canvasGroup.ignoreParentGroups = false;
            eventData.pointerDrag.transform.SetParent(this.transform);

        }

    }

    

}
