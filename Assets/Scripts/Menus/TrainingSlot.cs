using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingSlot : MonoBehaviour, IDropHandler
{
    public bool Monday, Tuesday, Wednesday, Thursday, Friday, TrainingMenu;
    public TrainingManager TrainingManager;

    public void OnDrop(PointerEventData eventData)
    {
        //print("Drop");
        TrainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();

        if (eventData.pointerDrag != null)
        {
            if (TrainingMenu)
            {
                if (eventData.pointerDrag.GetComponent<TrainingButton>().Monday)
                {
                    eventData.pointerDrag.GetComponent<TrainingButton>().Monday = false;
                    TrainingManager.Monday--;
                }
                else if (eventData.pointerDrag.GetComponent<TrainingButton>().Tuesday)
                {
                    eventData.pointerDrag.GetComponent<TrainingButton>().Tuesday = false;
                    TrainingManager.Tuesday--;

                }
                else if (eventData.pointerDrag.GetComponent<TrainingButton>().Wednesday)
                {
                    eventData.pointerDrag.GetComponent<TrainingButton>().Wednesday = false;
                    TrainingManager.Wednesday--;

                }
                else if (eventData.pointerDrag.GetComponent<TrainingButton>().Thursday)
                {
                    eventData.pointerDrag.GetComponent<TrainingButton>().Thursday = false;
                    TrainingManager.Thursday--;

                }
                else if (eventData.pointerDrag.GetComponent<TrainingButton>().Friday)
                {
                    eventData.pointerDrag.GetComponent<TrainingButton>().Friday = false;
                    TrainingManager.Friday--;

                }
                TrainingManager.UpcomingTrainings.Remove(eventData.pointerDrag.GetComponent<TrainingButton>().Training);
                eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = false;
            }
            else
            {
                if (eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar == true)
                {
                    if (eventData.pointerDrag.GetComponent<TrainingButton>().Monday)
                    {
                        eventData.pointerDrag.GetComponent<TrainingButton>().Monday = false;
                        TrainingManager.Monday--;
                    }
                    else if (eventData.pointerDrag.GetComponent<TrainingButton>().Tuesday)
                    {
                        eventData.pointerDrag.GetComponent<TrainingButton>().Tuesday = false;
                        TrainingManager.Tuesday--;

                    }
                    else if (eventData.pointerDrag.GetComponent<TrainingButton>().Wednesday)
                    {
                        eventData.pointerDrag.GetComponent<TrainingButton>().Wednesday = false;
                        TrainingManager.Wednesday--;

                    }
                    else if (eventData.pointerDrag.GetComponent<TrainingButton>().Thursday)
                    {
                        eventData.pointerDrag.GetComponent<TrainingButton>().Thursday = false;
                        TrainingManager.Thursday--;

                    }
                    else if (eventData.pointerDrag.GetComponent<TrainingButton>().Friday)
                    {
                        eventData.pointerDrag.GetComponent<TrainingButton>().Friday = false;
                        TrainingManager.Friday--;

                    }
                    TrainingManager.UpcomingTrainings.Remove(eventData.pointerDrag.GetComponent<TrainingButton>().Training);
                }

                if (Monday)
                {
                    
                        TrainingManager.Monday++;
                    
                    eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = true;
                    eventData.pointerDrag.GetComponent<TrainingButton>().Monday = true;
                }
                else if (Tuesday)
                {
                    
                        TrainingManager.Tuesday++;
                    
                    eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = true;                   
                    eventData.pointerDrag.GetComponent<TrainingButton>().Tuesday = true;

                }
                else if (Wednesday)
                {
                    
                        TrainingManager.Wednesday++;
                    
                    eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = true;                   
                    eventData.pointerDrag.GetComponent<TrainingButton>().Wednesday = true;

                }
                else if (Thursday)
                {
                    
                        TrainingManager.Thursday++;
                    
                    eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = true;                   
                    eventData.pointerDrag.GetComponent<TrainingButton>().Thursday = true;

                }
                else if (Friday)
                {
                   
                        TrainingManager.Friday++;
                    
                    eventData.pointerDrag.GetComponent<TrainingButton>().onCalendar = true;                   
                    eventData.pointerDrag.GetComponent<TrainingButton>().Friday = true;

                }
                TrainingManager.UpcomingTrainings.Add(eventData.pointerDrag.GetComponent<TrainingButton>().Training);

               
            }
            
            

            eventData.pointerDrag.GetComponent<TrainingButton>().dropped = true;
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;

            
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = gameObject.transform.position;
        }
    }




}
