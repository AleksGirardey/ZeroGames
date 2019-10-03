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
    }

    public void CalculVitesseMoyenne()
    {
        float distance = 320;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float TempsAcceleration = VitesseMax / Acceleration;
        float VitesseAccelerationMoy =
            (1 / (TempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2 / 3) * Mathf.Pow(TempsAcceleration, 1.5f);

        float TempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * TempsEndurance)) - (1 / TempsEndurance);
        float VitesseEnduMoy =
            (VitesseMax / TempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * TempsEndurance) + 1) - 1));

        if (distance <= (VitesseAccelerationMoy * TempsAcceleration) + (VitesseEnduMoy * TempsEndurance))
        {
            float distanceRaccourci = distance - (VitesseAccelerationMoy * TempsAcceleration);
            VitesseMoyenne = distance / ( TempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenne =
                distance / 
                (TempsAcceleration
                + TempsEndurance
                + ((distance - (VitesseAccelerationMoy * TempsAcceleration) - (VitesseEnduMoy * TempsEndurance)) * (VitesseMax * EndurancePourc)));
        }


    }

    public void CalculVitesseMoyenneDeuxTournant()
    {
        float distance = 525;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float TempsAcceleration = VitesseMax / Acceleration;
        float VitesseAccelerationMoy =
            (1 / (TempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2 / 3) * Mathf.Pow(TempsAcceleration, 1.5f);

        float TempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * TempsEndurance)) - (1 / TempsEndurance);
        float VitesseEnduMoy =
            (VitesseMax / TempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * TempsEndurance) + 1) - 1));

        if (distance <= (VitesseAccelerationMoy * TempsAcceleration) + (VitesseEnduMoy * TempsEndurance))
        {
            float distanceRaccourci = distance - (VitesseAccelerationMoy * TempsAcceleration);

            VitesseMoyenneDeuxTournant = distance / (TempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenneDeuxTournant =
                distance /
                (TempsAcceleration
                + TempsEndurance
                + ((distance - (VitesseAccelerationMoy * TempsAcceleration) - (VitesseEnduMoy * TempsEndurance)) * (VitesseMax * EndurancePourc)));
        }


    }

    public void CalculVitesseMoyenneTroisTournant()
    {
        float distance = 685;
        float EnduranceConso = 3;
        float EndurancePourc = 0.75f;

        float TempsAcceleration = VitesseMax / Acceleration;
        float VitesseAccelerationMoy =
            (1 / (TempsAcceleration))
            * VitesseMax
            * Mathf.Sqrt(Acceleration / VitesseMax)
            * (2 / 3) * Mathf.Pow(TempsAcceleration, 1.5f);

        float TempsEndurance = Endurance / EnduranceConso;
        float b = (1 / (EnduranceConso * EnduranceConso * TempsEndurance)) - (1 / TempsEndurance);
        float VitesseEnduMoy =
            (VitesseMax / TempsEndurance)
            * ((2 / b) * (Mathf.Sqrt((b * TempsEndurance) + 1) - 1));

        if (distance <= (VitesseAccelerationMoy * TempsAcceleration) + (VitesseEnduMoy * TempsEndurance))
        {
            float distanceRaccourci = distance - (VitesseAccelerationMoy * TempsAcceleration);
            VitesseMoyenneTroisTournant = distance / (TempsAcceleration
                + (-b + Mathf.Sqrt(Mathf.Pow(b, 2) + ((4 * Mathf.Pow(VitesseMax, 2)) / Mathf.Pow(distanceRaccourci, 2)))) /
                (2 * (Mathf.Pow(VitesseMax, 2) / Mathf.Pow(distanceRaccourci, 2))));
        }
        else
        {
            VitesseMoyenneTroisTournant =
                distance /
                (TempsAcceleration
                + TempsEndurance
                + ((distance - (VitesseAccelerationMoy * TempsAcceleration) - (VitesseEnduMoy * TempsEndurance)) * (VitesseMax * EndurancePourc)));
        }


    }

}