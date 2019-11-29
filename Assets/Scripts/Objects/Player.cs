using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
public class Player : ScriptableObject
{

    public Kennel kennel;

    public string profileName;
    public string greyhound;

    public int daysPlayed;
    public int money;
}