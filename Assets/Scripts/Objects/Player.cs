using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Player
{

    public Kennel kennel;

    public string profileName = "PlacerHolderName";
    public string greyhound;

    public int daysPlayed = 1;
    public int money = 7500;
}