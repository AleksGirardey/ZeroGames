using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DogHistory : MonoBehaviour
{
    public int RaceWon;
    public int MaxSpeedRun;
    public int MoneyEarned;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Won " + RaceWon + " Races\nWent at " + MaxSpeedRun + " miles per hour\n Earned you " + MoneyEarned + " £";
    }
}
