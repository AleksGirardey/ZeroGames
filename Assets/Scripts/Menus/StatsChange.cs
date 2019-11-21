using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsChange : MonoBehaviour
{
    public bool MaxSpeed;
    public bool Acceleration;
    public bool Stamina;

    public float _MaxSpeed;
    public float _Acceleration;
    public float _Stamina;

    public GameManager GM;

    private void Awake()
    {
        _MaxSpeed = GM.GetComponent<GameManager>().PlayerDogs[0].VitesseMax;
        _Acceleration = GM.GetComponent<GameManager>().PlayerDogs[0].Acceleration;
        _Stamina = GM.GetComponent<GameManager>().PlayerDogs[0].Endurance;

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
    }

    private void Update()
    {
        if (_MaxSpeed != GM.GetComponent<GameManager>().PlayerDogs[0].VitesseMax || _Acceleration != GM.GetComponent<GameManager>().PlayerDogs[0].Acceleration || _Stamina != GM.GetComponent<GameManager>().PlayerDogs[0].Endurance)
        {
            _MaxSpeed = GM.GetComponent<GameManager>().PlayerDogs[0].VitesseMax;
            _Acceleration = GM.GetComponent<GameManager>().PlayerDogs[0].Acceleration;
            _Stamina = GM.GetComponent<GameManager>().PlayerDogs[0].Endurance;

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
        }
    }

    void MaxSpeedSetUp()
    {
        if (_MaxSpeed < 250)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : C-";
        }
        else if (_MaxSpeed < 350)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : C";
        }
        else if (_MaxSpeed < 450)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : C+";
        }
        else if (_MaxSpeed < 550)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : B-";
        }
        else if (_MaxSpeed < 650)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : B";
        }
        else if (_MaxSpeed < 750)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : B+";
        }
        else if (_MaxSpeed < 850)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : A-";
        }
        else if (_MaxSpeed < 950)
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : A";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Max Speed : A+";
        }
        _MaxSpeed = 1;
    }

    void AccelerationSetUp()
    {
        if (_Acceleration < 250)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : C-";
        }
        else if (_Acceleration < 350)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : C";
        }
        else if (_Acceleration < 450)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : C+";
        }
        else if (_Acceleration < 550)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : B-";
        }
        else if (_Acceleration < 650)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : B";
        }
        else if (_Acceleration < 750)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : B+";
        }
        else if (_Acceleration < 850)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : A-";
        }
        else if (_Acceleration < 950)
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : A";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Acceleration : A+";
        }
    }

    void StaminaSetUp()
    {
        if (_Stamina < 250)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : C-";
        }
        else if (_Stamina < 350)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : C";
        }
        else if (_Stamina < 450)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : C+";
        }
        else if (_Stamina < 550)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : B-";
        }
        else if (_Stamina < 650)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : B";
        }
        else if (_Stamina < 750)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : B+";
        }
        else if (_Stamina < 850)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : A-";
        }
        else if (_Stamina < 950)
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : A";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Stamina : A+";
        }
    }

}