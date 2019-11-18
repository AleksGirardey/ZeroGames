using UnityEngine;
using System.Collections;

public class Chien : StatsChien
{
    public string Name;
    public int Age;

    Chien(string name, int age, float endurance, float acceleration, float vitesseMax) : base(endurance, acceleration, vitesseMax) {
        Name = name;
        Age = age;
    }
}
