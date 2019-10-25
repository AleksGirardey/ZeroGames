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
            Calendar.GetComponent<Calendar>().day += 7;
            ApplyNextWeekChange();
        }
    }

    void ApplyNextWeekChange()
    {
        for (int i = 0; i < Days.Length; i++)
        {
            Days[i].GetComponent<Day_training>().NextWeek();
        }
        Exhaust.GetComponent<Exhaust_Manager>().mon = 0;
        Exhaust.GetComponent<Exhaust_Manager>().tue = 0;
        Exhaust.GetComponent<Exhaust_Manager>().wed = 0;
        Exhaust.GetComponent<Exhaust_Manager>().thu = 0;
        Exhaust.GetComponent<Exhaust_Manager>().fri = 0;
    }
}
