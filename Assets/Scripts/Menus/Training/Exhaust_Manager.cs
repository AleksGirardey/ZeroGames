using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust_Manager : MonoBehaviour
{
    public int mon;
    public int tue;
    public int wed;
    public int thu;
    public int fri;


    public GameObject Tuesday;
    public GameObject Wednesday;
    public GameObject Thursday;
    public GameObject Friday;

    private void Start()
    {
        mon = 0;
        tue = 0;
        wed = 0;
        thu = 0;
        fri = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mon = Mathf.Clamp(mon, 0, 2);
        tue = Mathf.Clamp(tue, 0, 2);
        wed = Mathf.Clamp(wed, 0, 2);
        thu = Mathf.Clamp(thu, 0, 2);
        fri = Mathf.Clamp(fri, 0, 2);

        
        Tuesday.GetComponent<Exhaust_holder>().energy = 3 - mon;
        
        
        
        if (mon == 2)
        {
            Wednesday.GetComponent<Exhaust_holder>().energy = 3 - tue - 1;
        }
        else
        {
            Wednesday.GetComponent<Exhaust_holder>().energy = 3 - tue;
        }

        if (tue == 2)
        {
            Thursday.GetComponent<Exhaust_holder>().energy = 3 - wed - 1;
        }
        else
        {
            Thursday.GetComponent<Exhaust_holder>().energy = 3 - wed;
        }
        if (wed == 2)
        {
            Friday.GetComponent<Exhaust_holder>().energy = 3 - thu - 1;
        }
        else
        {
            Friday.GetComponent<Exhaust_holder>().energy = 3 - thu;
        }
        
        

    }
}
