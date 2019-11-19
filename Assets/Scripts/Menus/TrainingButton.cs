using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainingButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Training Training;
    private RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    private Vector3 initialPos;
    public bool dropped;
    public bool onCalendar;
    public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    public TrainingSlot TrainingSlot;
    public Transform ParentWhileDrag;
    private Transform initialParent;
    public Text Name;

    public void SetName(string name)
    {
        Name.text = name;
    }

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(TrainingSlot != null && TrainingSlot.training == Training)
        {
            TrainingSlot.training = null;
        }
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
       // canvasGroup.ignoreParentGroups = true;
        //print("drag begin");
        initialParent = transform.parent;
        transform.SetParent(ParentWhileDrag); // SETPARENT MARCHE MAIS PAS DANS LINSPECTEUR MAIS VISUELLEMENT CELA CHANGE QUELQUE  CHOSE

        initialPos = transform.position;
        dropped = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        //print("end drag");
        if (!dropped)
        {
            transform.position = initialPos;
            transform.SetParent(initialParent);
            // canvasGroup.ignoreParentGroups = false;
        }
        

    }
    
   
}
