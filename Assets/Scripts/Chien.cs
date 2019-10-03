using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chien {
    public string Nom;

    public float VitesseMaxDefault;
    public float AccelerationDefault;
    public float EnduranceDefault;
    public float ForceDefault;
    public float MentalDefault;
    
    public float VitesseMax;
    public float Endurance;
    public float Acceleration;
    public float Force;
    public float Mental;
    
    public float VitesseMoyenne;
    public float VitesseMoyenneDeuxTournant;
    public float VitesseMoyenneTroisTournant;

    public Chien(string nom,
        float vitesseMaxDefault,
        float enduranceDefault,
        float forceDefault,
        float accelerationDefault,
        float mentalDefault)
    {

        Nom = nom;
        VitesseMaxDefault = vitesseMaxDefault;
        VitesseMax = vitesseMaxDefault;
        Endurance = enduranceDefault;
        EnduranceDefault = enduranceDefault;
        Force = forceDefault;
        ForceDefault = forceDefault;
        Acceleration = accelerationDefault;
        AccelerationDefault = accelerationDefault;
        Mental = mentalDefault;
        MentalDefault = mentalDefault;

        // Calcul vitesse / temps
        CalculVitesseMoyenne();
        CalculVitesseMoyenneDeuxTournant();
        CalculVitesseMoyenneTroisTournant();
    }

    public void CalculVitesseMoyenne()
    {
        float distance = 320;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float tempsAcceleration = VitesseMax / Acceleration;
        float vitesseAccelerationMoy =
            (1 / (tempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2f / 3f) * Mathf.Pow(tempsAcceleration, 1.5f);

        float tempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * tempsEndurance)) - (1 / tempsEndurance);
        float vitesseEnduMoy =
            (VitesseMax / tempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * tempsEndurance) + 1) - 1));

        if (distance <= (vitesseAccelerationMoy * tempsAcceleration) + (vitesseEnduMoy * tempsEndurance))
        {
            float distanceRaccourci = distance - (vitesseAccelerationMoy * tempsAcceleration);
            VitesseMoyenne = distance / ( tempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenne =
                distance / 
                (tempsAcceleration
                + tempsEndurance
                + ((distance - (vitesseAccelerationMoy * tempsAcceleration) - (vitesseEnduMoy * tempsEndurance)) * (VitesseMax * EndurancePourc)));
        }


    }

    public void CalculVitesseMoyenneDeuxTournant()
    {
        float distance = 525;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float tempsAcceleration = VitesseMax / Acceleration;
        float vitesseAccelerationMoy =
            (1 / (tempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2f / 3f) * Mathf.Pow(tempsAcceleration, 1.5f);

        float tempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * tempsEndurance)) - (1 / tempsEndurance);
        float vitesseEnduMoy =
            (VitesseMax / tempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * tempsEndurance) + 1) - 1));

        if (distance <= (vitesseAccelerationMoy * tempsAcceleration) + (vitesseEnduMoy * tempsEndurance))
        {
            float distanceRaccourci = distance - (vitesseAccelerationMoy * tempsAcceleration);

            VitesseMoyenneDeuxTournant = distance / (tempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenneDeuxTournant =
                distance /
                (tempsAcceleration
                + tempsEndurance
                + ((distance - (vitesseAccelerationMoy * tempsAcceleration) - (vitesseEnduMoy * tempsEndurance)) * (VitesseMax * EndurancePourc)));
        }


    }

    public void CalculVitesseMoyenneTroisTournant()
    {
        float distance = 685;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float tempsAcceleration = VitesseMax / Acceleration;
        float vitesseAccelerationMoy =
            (1 / (tempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2f / 3f) * Mathf.Pow(tempsAcceleration, 1.5f);

        float tempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * tempsEndurance)) - (1 / tempsEndurance);
        float vitesseEnduMoy =
            (VitesseMax / tempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * tempsEndurance) + 1) - 1));

        if (distance <= (vitesseAccelerationMoy * tempsAcceleration) + (vitesseEnduMoy * tempsEndurance))
        {
            float distanceRaccourci = distance - (vitesseAccelerationMoy * tempsAcceleration);
            VitesseMoyenneTroisTournant = distance / (tempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenneTroisTournant =
                distance /
                (tempsAcceleration
                + tempsEndurance
                + ((distance - (vitesseAccelerationMoy * tempsAcceleration) - (vitesseEnduMoy * tempsEndurance)) * (VitesseMax * EndurancePourc)));
        }
    }

    private class CompareOneLapClass : IComparer<Chien> {
        public int Compare(Chien a, Chien b) {
            if (a.VitesseMoyenne > b.VitesseMoyenne)
                return 1;
            if (a.VitesseMoyenne < b.VitesseMoyenne)
                return -1;
            return 0;
        }
    }

    private class CompareTwoLapClass : IComparer<Chien> {
        public int Compare(Chien a, Chien b) {
            if (a.VitesseMoyenneDeuxTournant > b.VitesseMoyenneDeuxTournant)
                return 1;
            if (a.VitesseMoyenneDeuxTournant < b.VitesseMoyenneDeuxTournant)
                return -1;
            return 0;
        }
    }

    private class CompareThreeLapClass : IComparer<Chien> {
        public int Compare(Chien a, Chien b) {
            if (a.VitesseMoyenneTroisTournant > b.VitesseMoyenneTroisTournant)
                return 1;
            if (a.VitesseMoyenneTroisTournant < b.VitesseMoyenneTroisTournant)
                return -1;
            return 0;
        }
    }

    public static IComparer<Chien> CompareOneLap() {
        return new CompareOneLapClass();
    }

    public static IComparer<Chien> CompareTwoLap() {
        return new CompareTwoLapClass();
    }

    public static IComparer<Chien> CompareThreeLap() {
        return new CompareThreeLapClass();
    }
}