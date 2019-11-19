using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TrainingsScriptableObject", order = 1)]
public class Training : ScriptableObject
{
    public float EnduranceDef;
    public float AccelerationDef;
    public float VitesseMaxDef;

    public float EnduranceTempo;
    public float AccelerationTempo;
    public float VitesseMaxTempo;

    public int WeekLeft;


}
