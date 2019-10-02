using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chien : System.Object
{

    public string Nom;
    public float VitesseMax;
    public float Endurance;
    public float Force;
    public float Acceleration;
    public float Mental;
    public float VitesseMoyenne;

    public Chien(string nom, float vmax, float endurance, float force, float acceleration, float mental)
    {

        Nom = nom;
        VitesseMax = vmax;
        Endurance = endurance;
        Force = force;
        Acceleration = acceleration;
        Mental = mental;
        VitesseMoyenne = VitesseMoyenneCalculee(VitesseMax, Acceleration, Endurance);

    }

    public float VitesseMoyenneCalculee(float vmax, float accel, float endur)
    {

        float Aire1 = (vmax * (vmax / accel)) / 2f;
        float Aire2 = ((vmax / ((1- endur / 100) * accel)) * vmax) / 2f;
        float Integrale = Aire1 + Aire2;

        float Intervalle = (vmax / ((1 - endur / 100) * accel)) + (vmax / accel);

        return (Integrale * (1 / Intervalle));

    }

}