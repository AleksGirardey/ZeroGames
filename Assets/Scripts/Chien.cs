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
        CalculVitesseMoyenne();
    }

    public void CalculVitesseMoyenne()
    {

        float aire1 = (VitesseMax * (VitesseMax / Acceleration)) / 2f;
        float aire2 = ((VitesseMax / ((1- Endurance / 100) * Acceleration)) * VitesseMax) / 2f;
        float integrale = aire1 + aire2;

        float intervalle = (VitesseMax / ((1 - Endurance / 100) * Acceleration)) + (VitesseMax / Acceleration);

        VitesseMoyenne = (integrale * (1 / intervalle));

    }

}