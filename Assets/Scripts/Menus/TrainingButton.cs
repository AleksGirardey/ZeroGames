using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Training Training;
    private RectTransform rectTransform;
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 initialPos;
    public bool dropped;
    public bool onCalendar;
    public bool Monday, Tuesday, Wednesday, Thursday, Friday;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        //print("drag begin");
        
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
        if(!dropped) transform.position = initialPos;

    }
    
   
}
