using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatsChienScriptableObject", order = 1)]
public class StatsChien : ScriptableObject
{
    public float Endurance;
    public float Acceleration;
    public float VitesseMax;

    public string LatestRace;
    public int LatestRank;

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