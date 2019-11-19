using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Chien : StatsChien
{
    public new string Name;
    [FormerlySerializedAs("Age")] public int age;

    Chien(string name, int age, float endurance, float acceleration, float vitesseMax) : base(endurance, acceleration, vitesseMax) {
        Name = name;
        this.age = age;
    }
}
