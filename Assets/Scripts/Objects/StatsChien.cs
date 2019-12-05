using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class StatsChien : ScriptableObject
{
    private static readonly Dictionary<int, string> statLetters = new Dictionary<int, string>() {
        {249, "C-"}, 
        {349, "C"}, 
        {449, "C+"}, 
        {549, "B-"}, 
        {649, "B"}, 
        {749, "B+"}, 
        {849, "A-"}, 
        {949, "A"}, 
        {1000, "A+"}
    };
    
    public string LatestRace;
    public int LatestRank;
    public float Endurance;
    public float Acceleration;
    public float VitesseMax;

    public float EnduranceDef;
    public float AccelerationDef;
    public float VitesseMaxDef;

    public string NatureKey;

    public int Wins, Looses;

    public string DescriptionKey;

    public int NumberRaceWon;
    public int NumberRaceLost;
    public int MaxSpeedRun;
    public int MoneyEarned;

    public List<Training> EnduranceTempo = new List<Training>();
    public List<Training> AccelerationTempo = new List<Training>();
    public List<Training> VitesseMaxTempo = new List<Training>();

    public bool TrainingsConfirmed;

    public List<Training> UpcomingTrainings = new List<Training>();
    
    public StatsChien(float Endu, float Accel, float Vmax, string lrace, int lrank)
    {
        Endurance = Endu;
        Acceleration = Accel;
        VitesseMax = Vmax;
        LatestRace = lrace;
        LatestRank = lrank;
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

    private string GetStatAsLetter(float value) {
        foreach (var key in statLetters.Keys.Where(key => (value <= key))) {
            return statLetters[key];
        }

        return "C-";
    }
    
    public string GetAccelerationAsLetter() {
        return GetStatAsLetter(GetAcceleration());
    }

    public string GetMaxSpeedAsLetter() {
        return GetStatAsLetter(GetVitesseMax());
    }

    public string GetStaminaAsLetter() {
        return GetStatAsLetter(GetEndurance());
    }
    
    public void AssignTrainings()
    {
        foreach(Training training in UpcomingTrainings)
        {
            if(training.EnduranceTempo != 0)
            {
                EnduranceTempo.Add(training);
            }

            if (training.AccelerationTempo != 0)
            {
                AccelerationTempo.Add(training);
            }

            if (training.VitesseMaxTempo != 0)
            {
                VitesseMaxTempo.Add(training);
            }

            if (training.EnduranceDef != 0)
            {
                EnduranceDef+=training.EnduranceDef;
            }

            if (training.AccelerationDef != 0)
            {
                AccelerationDef+=training.AccelerationDef;
            }

            if (training.VitesseMaxDef != 0)
            {
                VitesseMaxDef+=training.VitesseMaxDef;
            }
        }
        UpcomingTrainings.Clear();
    }

}