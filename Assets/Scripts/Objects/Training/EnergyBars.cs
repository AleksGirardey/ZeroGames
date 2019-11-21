﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBars : MonoBehaviour
{
    public TrainingDay trainingDay;
    public Image energyBar1;
    public Image energyBar2;
    public Image energyBar3;
    public Color RedEnergy, OrangeEnergy, GreenEnergy, EmptyEnergy;

    public EnergyBars previousDay, nextDay;
    public int EnergyBarsAvailable = 3;
    public int EnergyUsed, MinEnergy = 0;

    // Start is called before the first frame update
    void Start() {
        trainingDay = GetComponentInParent<TrainingDay>();
        SetColorGreen();
    }

    public void UpdEnergy(EnergyBars previousDay, int energyUsed)
    {
        if(previousDay == null)
        {
            return;
        }
        previousDay.MinEnergy = energyUsed;

        if (energyUsed != 0 && previousDay.previousDay != null)
        {
            UpdEnergy(previousDay.previousDay, energyUsed - 1);
        }

        // QUAND ON POSE, EnergyAvailable - 1 >= MinEnergy SI FALSE ON POSE PAS
    }

    // Update is called once per frame
    void Update()
    {
        EnergyUsed = 3 - EnergyBarsAvailable;

        //MinEnergy = nextDay.EnergyUsed - 1;

        // Si on pose X entrainement, le jour d'avant doit avoir au minimum X - 1 d'énergie dispo. 
        // UpdEnergy(previousDay, X) MinEnergy = 

        

        if(previousDay == null) EnergyBarsAvailable = 3;
        else
        {
          EnergyBarsAvailable = Mathf.Clamp(previousDay.EnergyBarsAvailable + 1, 0, 3);
        }

        foreach(TrainingSlot ts in trainingDay.trainingSlots)
        {
            if (ts.training != null) EnergyBarsAvailable--;

        }

        switch (EnergyBarsAvailable)
        {
            case 3:
                SetColorGreen();
                break;
            case 2:
                SetColorOrange();
                break;
            case 1:
                SetColorRed();
                break;
            default:
                SetColorEmpty();
                break;
        }
    }

    void SetColorGreen() {
        energyBar1.color = GreenEnergy;
        energyBar2.color = GreenEnergy;
        energyBar3.color = GreenEnergy;
    }

    void SetColorOrange()
    {
        energyBar1.color = OrangeEnergy;
        energyBar2.color = OrangeEnergy;
        energyBar3.color = EmptyEnergy;
    }
    void SetColorRed()
    {
        energyBar1.color = RedEnergy;
        energyBar2.color = EmptyEnergy;
        energyBar3.color = EmptyEnergy;
    }
    void SetColorEmpty()
    {
        energyBar1.color = EmptyEnergy;
        energyBar2.color = EmptyEnergy;
        energyBar3.color = EmptyEnergy;
    }

    public int EnergyBarNb()
    {
        return EnergyBarsAvailable;
    }
    public int NextEnergyBarNb()
    {
        if(nextDay != null)
        {
            return nextDay.EnergyBarsAvailable;
        }
        else
        {
            return 3;
        }
        
    }

}
