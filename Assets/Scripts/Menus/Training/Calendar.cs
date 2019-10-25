using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public int day;
    public int month;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( day >= 30)
        {
            if (month == 2 || month == 4 || month == 6 || month == 9 || month == 11)
            {
                day -= 30;
                month += 1;
            }
            else if ( day >= 31)
            {
                day -= 31;
                month += 1;
            }
        }
        if ( day == 0)
        {
            day = 1;
        }
        if (month > 12)
        {
            month = 1;
        }

        GetComponent<Texte>().t.GetComponent<TextMesh>().text = day + "/" + month;
    }
}
