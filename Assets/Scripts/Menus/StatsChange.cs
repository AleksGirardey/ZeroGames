using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsChange : MonoBehaviour
{
    public bool MaxSpeed;
    public bool Acceleration;
    public bool Stamina;

    public float _MaxSpeed;
    public float _Acceleration;
    public float _Stamina;

    public GameManager GM;


    private void Start()
    {
        GM = GameManager.Instance;
    }

    private void Update()
    {  
            _MaxSpeed = GM.Player.kennel.dogs[0].VitesseMax;
            _Acceleration = GM.Player.kennel.dogs[0].Acceleration;
            _Stamina = GM.Player.kennel.dogs[0].Endurance;

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

}