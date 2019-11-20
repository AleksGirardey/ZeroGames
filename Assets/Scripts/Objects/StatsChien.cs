﻿using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatsChienScriptableObject", order = 1)]
public class StatsChien : ScriptableObject
{
    public float Endurance;
    public float Acceleration;
    public float VitesseMax;

    public float EnduranceDef;
    public float AccelerationDef;
    public float VitesseMaxDef;

    public List<Training> EnduranceTempo = new List<Training>();
    public List<Training> AccelerationTempo = new List<Training>();
    public List<Training> VitesseMaxTempo = new List<Training>();

    public Color imgColor;

    public string Name;

    public bool TrainingsConfirmed;

    public List<Training> UpcomingTrainings = new List<Training>();

    public StatsChien(float Endu, float Accel, float Vmax)
    {
        Endurance = Endu;
        Acceleration = Accel;
        VitesseMax = Vmax;
    }

    public float GetEndurance()
    {
        float enduranceTempo = 0;
        foreach (Training training in EnduranceTempo)
        {
            enduranceTempo += training.EnduranceTempo;
        }

        return Endurance + EnduranceDef + enduranceTempo;
    }

    public float GetAcceleration()
    {
        float accelerationTempo = 0;
        foreach (Training training in AccelerationTempo)
        {
            accelerationTempo += training.AccelerationTempo;
        }

        return Acceleration + AccelerationDef + accelerationTempo;
    }

    public float GetVitesseMax()
    {
        float vitesseMaxTempo = 0;
        foreach (Training training in VitesseMaxTempo)
        {
            vitesseMaxTempo += training.VitesseMaxTempo;
        }

        return VitesseMax + VitesseMaxDef + vitesseMaxTempo;
    }

    public void ClearTraining()
    {
        List<Training> newList = new List<Training>();

        // Clear Endurance
        foreach (Training training in EnduranceTempo)
        {
            training.WeekLeft--;
            if (training.WeekLeft > 0)
                newList.Add(training);
        }
        EnduranceTempo = newList;
        newList.Clear();

        // Clear Acceleration
        foreach (Training training in AccelerationTempo)
        {
            training.WeekLeft--;
            if (training.WeekLeft > 0)
                newList.Add(training);
        }
        AccelerationTempo = newList;
        newList.Clear();

        // Clear VitesseMax
        foreach (Training training in VitesseMaxTempo)
        {
            training.WeekLeft--;
            if (training.WeekLeft > 0)
                newList.Add(training);
        }
        VitesseMaxTempo = newList;
    }
}