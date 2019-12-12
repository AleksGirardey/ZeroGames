using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DogScriptableObject", order = 1)]
public class Dog : StatsChien {

    [FormerlySerializedAs("Name")] public string dogName;
    [FormerlySerializedAs("Age")] public string age;
    [FormerlySerializedAs("Width")] public float width;
    [FormerlySerializedAs("Height")] public float height;

    public Sprite avatar;

    public int lapsPreference;
    
    public Dog(float endu, float accel, float vmax, string lrace, int lrank, string name) :
        base(endu, accel, vmax, lrace, lrank) {
        dogName = name;
    }
}