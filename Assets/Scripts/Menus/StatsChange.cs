using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsChange : MonoBehaviour
{
    public bool MaxSpeed;
    public bool Acceleration;
    public bool Stamina;
    public bool Mental;

    public float _MaxSpeed;
    public float _Acceleration;
    public float _Stamina;
    public float _Mental;

    public KennelManager KM;


    private void Update()
    {
        _MaxSpeed = KM.SelectedDog.VitesseMax;
            _Acceleration = KM.SelectedDog.Acceleration;
        _Stamina = KM.SelectedDog.Endurance;
        _Mental = KM.SelectedDog.Mental;

        if (MaxSpeed)
            {
                MaxSpeedSetUp();
            }
            else if (Acceleration)
            {
                AccelerationSetUp();
            }
            else if (Stamina)
            {
                StaminaSetUp();
            }
            else if (Mental)
            {
                MentalSetUp();
            }
    }

    void MaxSpeedSetUp()
    {
        if (_MaxSpeed < 250)
        {
            GetComponent<Text>().text = "Max Speed : C-";
        }
        else if (_MaxSpeed < 350)
        {
            GetComponent<Text>().text = "Max Speed : C";
        }
        else if (_MaxSpeed < 450)
        {
            GetComponent<Text>().text = "Max Speed : C+";
        }
        else if (_MaxSpeed < 550)
        {
            GetComponent<Text>().text = "Max Speed : B-";
        }
        else if (_MaxSpeed < 650)
        {
            GetComponent<Text>().text = "Max Speed : B";
        }
        else if (_MaxSpeed < 750)
        {
            GetComponent<Text>().text = "Max Speed : B+";
        }
        else if (_MaxSpeed < 850)
        {
            GetComponent<Text>().text = "Max Speed : A-";
        }
        else if (_MaxSpeed < 950)
        {
            GetComponent<Text>().text = "Max Speed : A";
        }
        else
        {
            GetComponent<Text>().text = "Max Speed : A+";
        }
        _MaxSpeed = 1;
    }

    void AccelerationSetUp()
    {
        if (_Acceleration < 250)
        {
            GetComponent<Text>().text = "Acceleration : C-";
        }
        else if (_Acceleration < 350)
        {
            GetComponent<Text>().text = "Acceleration : C";
        }
        else if (_Acceleration < 450)
        {
            GetComponent<Text>().text = "Acceleration : C+";
        }
        else if (_Acceleration < 550)
        {
            GetComponent<Text>().text = "Acceleration : B-";
        }
        else if (_Acceleration < 650)
        {
            GetComponent<Text>().text = "Acceleration : B";
        }
        else if (_Acceleration < 750)
        {
            GetComponent<Text>().text = "Acceleration : B+";
        }
        else if (_Acceleration < 850)
        {
            GetComponent<Text>().text = "Acceleration : A-";
        }
        else if (_Acceleration < 950)
        {
            GetComponent<Text>().text = "Acceleration : A";
        }
        else
        {
            GetComponent<Text>().text = "Acceleration : A+";
        }
    }

    void StaminaSetUp()
    {
        if (_Stamina < 250)
        {
            GetComponent<Text>().text = "Stamina : C-";
        }
        else if (_Stamina < 350)
        {
            GetComponent<Text>().text = "Stamina : C";
        }
        else if (_Stamina < 450)
        {
            GetComponent<Text>().text = "Stamina : C+";
        }
        else if (_Stamina < 550)
        {
            GetComponent<Text>().text = "Stamina : B-";
        }
        else if (_Stamina < 650)
        {
            GetComponent<Text>().text = "Stamina : B";
        }
        else if (_Stamina < 750)
        {
            GetComponent<Text>().text = "Stamina : B+";
        }
        else if (_Stamina < 850)
        {
            GetComponent<Text>().text = "Stamina : A-";
        }
        else if (_Stamina < 950)
        {
            GetComponent<Text>().text = "Stamina : A";
        }
        else
        {
            GetComponent<Text>().text = "Stamina : A+";
        }
    }

    void MentalSetUp()
    {
        if (_Mental < 250)
        {
            GetComponent<Text>().text = "Mental : C-";
        }
        else if (_Mental < 350)
        {
            GetComponent<Text>().text = "Mental : C";
        }
        else if (_Mental < 450)
        {
            GetComponent<Text>().text = "Mental : C+";
        }
        else if (_Mental < 550)
        {
            GetComponent<Text>().text = "Mental : B-";
        }
        else if (_Mental < 650)
        {
            GetComponent<Text>().text = "Mental : B";
        }
        else if (_Mental < 750)
        {
            GetComponent<Text>().text = "Mental : B+";
        }
        else if (_Mental < 850)
        {
            GetComponent<Text>().text = "Mental : A-";
        }
        else if (_Mental < 950)
        {
            GetComponent<Text>().text = "Mental : A";
        }
        else
        {
            GetComponent<Text>().text = "Mental : A+";
        }
    }

}