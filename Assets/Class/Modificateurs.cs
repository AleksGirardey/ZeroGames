using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Modificateurs
{
    private int ModificateurVitesseMax;
    private int ModificateurAcceleration;
    private int ModificateurEndurance;

    public Modificateurs(int vmax, int acc, int end)
    {
        ModificateurVitesseMax = vmax;
        ModificateurAcceleration = acc;
        ModificateurEndurance = end;
    }

    public void SetModificateurVitesseMax(int newVitesse)
    {
        if (newVitesse > 100) return;
        ModificateurVitesseMax = newVitesse;
    }

    public int GetModificateurVitesseMax() {
        return ModificateurVitesseMax;
    }

    public void SetModificateurAcceleration(int newAcc)
    {
        ModificateurAcceleration = newAcc;
    }

    public int GetModificateurAcceleration()
    {
        return ModificateurAcceleration;
    }

    public void SetModificateurEndurance(int newEndurance)
    {
        ModificateurEndurance = newEndurance;
    }

    public int GetModificateurEndurance()
    {
        return ModificateurEndurance;
    }
}
