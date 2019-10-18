<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatsChienScriptableObject", order = 1)]
public class StatsChien : ScriptableObject
{
    public float Endurance;
    public float Acceleration;
    public float VitesseMax;

    public StatsChien(float Endu, float Accel, float Vmax)
    {
        Endurance = Endu;
        Acceleration = Accel;
        VitesseMax = Vmax;
    }

    public float GetEndurance()
    {
        return Endurance;
    }

    public float GetAcceleration()
    {
        return Acceleration;
    }

    public float GetVitesseMax()
    {
        return VitesseMax;
    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatsChienScriptableObject", order = 1)]
public class StatsChien : ScriptableObject
{
    public float Endurance;
    public float Acceleration;
    public float VitesseMax;

    public StatsChien(float Endu, float Accel, float Vmax)
    {
        Endurance = Endu;
        Acceleration = Accel;
        VitesseMax = Vmax;
    }

    public float GetEndurance()
    {
        return Endurance;
    }

    public float GetAcceleration()
    {
        return Acceleration;
    }

    public float GetVitesseMax()
    {
        return VitesseMax;
    }

}
>>>>>>> Stashed changes
