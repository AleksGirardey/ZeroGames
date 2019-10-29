using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekAhead : MonoBehaviour
{
    public GameObject Calendar;

    public GameObject[] Days;

    public GameObject Exhaust;

    private void OnMouseOver()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Calendar.GetComponent<Calendar>().day += 7; // Add 7 days to the count, as a week.
            ApplyNextWeekChange(); 
        }
    }

    void ApplyNextWeekChange()
    {
        for (int i = 0; i < Days.Length; i++)
        {
            Days[i].GetComponent<Day_training>().NextWeek(); // Reset the days to have no training.
        }
        Exhaust.GetComponent<Exhaust_Manager>().mon = 0;
        Exhaust.GetComponent<Exhaust_Manager>().tue = 0;
        Exhaust.GetComponent<Exhaust_Manager>().wed = 0;
        Exhaust.GetComponent<Exhaust_Manager>().thu = 0;
        Exhaust.GetComponent<Exhaust_Manager>().fri = 0;
        // Reset the exhaustion of the different days.
    }
}
