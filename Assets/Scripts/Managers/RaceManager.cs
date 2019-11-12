using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public StatsChien[] ListeDesChiens = new StatsChien[20];

    public DogMovement[] Chiens = new DogMovement[4];

    public Text Endurance;
    public Text VitesseMax;
    public Text Acceleration;
    public Text VitesseMoyenne;
    public Text Countdown;

    public LayerMask ChienLayer;

    public bool RaceStarted;
    public bool CountdownStarted;
    public Transform StartPoint;

    private float _startDiff; // Ecarter les chiens au début

    public GameManager GameManager;
    public int Turns;
    public int i1, i2, i3;
    public bool Day, Night, Rain, Sun;
    public Text RaceInfosTxt;
    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Countdown.text = "";
        Turns = GameManager.Turns;
        /*
        foreach (DogMovement chien in Chiens) // Générer 4 chiens aléatoire parmis les 20 dans Assets/Ressources/Chiens
        {
            int i = Random.Range(0, ListeDesChiens.Length);

            chien.Endurance = ListeDesChiens[i].GetEndurance();
            chien.VitesseMax = ListeDesChiens[i].GetVitesseMax();
            chien.Acceleration = ListeDesChiens[i].GetAcceleration();
        }*/

        if(Random.Range(0,100) < 50)
        {
            Day = true;
        }
        else
        {
            Night = true;
        }
        if (Random.Range(0, 100) < 50)
        {
            Rain = true;
        }
        else
        {
            Sun = true;
        }
        RaceInfosTxt.text = "Infos course: \n Jour: " + Day + " Night: " + Night + "\n Rain: " + Rain + " Sun: " + Sun + "\n Nb de tours: " + Turns.ToString();

        // CHIEN DU JOUEUR
        Chiens[0].Endurance = GameManager.PlayerDogs[0].Endurance;
        Chiens[0].VitesseMax = GameManager.PlayerDogs[0].VitesseMax;
        Chiens[0].Acceleration = GameManager.PlayerDogs[0].Acceleration;


        if (Turns == 1) // 2 CHIENS AVEC GROSSE ACCEL
        {
            i1 = Random.Range(0, ListeDesChiens.Length);
            Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
            Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
            Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            while (Chiens[1].Acceleration < 21)
            {
                i1 = Random.Range(0, ListeDesChiens.Length);
                Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
                Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
                Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            }

            i2 = Random.Range(0, ListeDesChiens.Length);
            Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
            Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
            Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            while (Chiens[2].Acceleration < 21 || i2 == i1)
            {
                i2 = Random.Range(0, ListeDesChiens.Length);
                Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
                Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
                Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            }

            i3 = Random.Range(0, ListeDesChiens.Length);
            Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
            Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
            Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            while (i3 == i2 || i3 == i1)// 1 CHIEN RANDOM
            {
                i3 = Random.Range(0, ListeDesChiens.Length);
                Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
                Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
                Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            }
        }
        else if(Turns == 2) // 2 CHIENS AVEC STATS MOYENNE (EN DESSOUS DE 30)
        {
            i1 = Random.Range(0, ListeDesChiens.Length);
            Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
            Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
            Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            while (Chiens[1].Endurance > 30 && Chiens[1].VitesseMax > 30 && Chiens[1].Acceleration > 30)
            {
                i1 = Random.Range(0, ListeDesChiens.Length);
                Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
                Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
                Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            }

            i2 = Random.Range(0, ListeDesChiens.Length);
            Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
            Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
            Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            while ((Chiens[2].Endurance > 30 && Chiens[2].VitesseMax > 30 && Chiens[2].Acceleration > 30) || i2 == i1)
            {
                i2 = Random.Range(0, ListeDesChiens.Length);
                Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
                Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
                Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            }

            i3 = Random.Range(0, ListeDesChiens.Length);
            Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
            Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
            Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            while (i3 == i2 || i3 == i1)// 1 CHIEN RANDOM
            {
                i3 = Random.Range(0, ListeDesChiens.Length);
                Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
                Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
                Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            }
        }
        else if (Turns == 3) // 2 CHIENS AVEC GROSSE ENDURANCE
        {
            i1 = Random.Range(0, ListeDesChiens.Length);
            Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
            Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
            Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            while (Chiens[1].Endurance < 29)
            {
                i1 = Random.Range(0, ListeDesChiens.Length);
                Chiens[1].Endurance = ListeDesChiens[i1].GetEndurance();
                Chiens[1].VitesseMax = ListeDesChiens[i1].GetVitesseMax();
                Chiens[1].Acceleration = ListeDesChiens[i1].GetAcceleration();
            }

            i2 = Random.Range(0, ListeDesChiens.Length);
            Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
            Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
            Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            while (Chiens[2].Endurance < 29 || i2 == i1)
            {
                i2 = Random.Range(0, ListeDesChiens.Length);
                Chiens[2].Endurance = ListeDesChiens[i2].GetEndurance();
                Chiens[2].VitesseMax = ListeDesChiens[i2].GetVitesseMax();
                Chiens[2].Acceleration = ListeDesChiens[i2].GetAcceleration();
            }

            i3 = Random.Range(0, ListeDesChiens.Length);
            Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
            Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
            Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            while (i3 == i2 || i3 == i1)// 1 CHIEN RANDOM
            {
                i3 = Random.Range(0, ListeDesChiens.Length);
                Chiens[3].Endurance = ListeDesChiens[i3].GetEndurance();
                Chiens[3].VitesseMax = ListeDesChiens[i3].GetVitesseMax();
                Chiens[3].Acceleration = ListeDesChiens[i3].GetAcceleration();
            }
        }
        else
        {
            print("error, turn nb != 1, 2, 3");
        }
        
        
        


    }

    private void Update()
    {
        // if (!RaceStarted) SelectChien();
        DisplayChienStats();
    }

    public void StartRace()
    {
        foreach (DogMovement dog in Chiens)
        {
            dog.transform.position = StartPoint.position + new Vector3(_startDiff, 0, 0); // Mettre les chiens à pos. de départ et les écarter entre eux
            _startDiff += 0.2f;
        }
        if (!CountdownStarted)
        {
            StartCoroutine("RaceCountdown");
            CountdownStarted = true;
        }
    }

    void DisplayChienStats()
    {
        RaycastHit hit;
        Transform chienSelected = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer)) // Quand la souris passe sur un chien
        {
            chienSelected = hit.transform;
            chienSelected.localScale = new Vector3(0.5f, 0.5f, -0.5f); // On rescale le chien

            Endurance.text = "endurance : " + chienSelected.GetComponent<DogMovement>().Endurance; // Actualisation des stats
            VitesseMax.text = "vitesse max : " + chienSelected.GetComponent<DogMovement>().VitesseMax;
            Acceleration.text = "accélération : " + chienSelected.GetComponent<DogMovement>().Acceleration;
            VitesseMoyenne.text = "vitesse moyenne: " + chienSelected.GetComponent<DogMovement>().VitesseMoyenne;
        }

        for (int i = 0; i < Chiens.Length; i++) // Reset le scale du chien si déselectionné
        {
            if (Chiens[i].transform != chienSelected) Chiens[i].transform.localScale = new Vector3(0.2f, 0.2f, -0.2f);
        }
    }

    void SelectChien() // Choix du chien, disabled atm
    {
        RaycastHit hit;
        Transform chienSelected = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer) && !CountdownStarted) // Quand la souris passe sur un chien
        {
            chienSelected = hit.transform;
            chienSelected.localScale = new Vector3(0.5f,0.5f,-0.5f); // On rescale le chien

            Endurance.text = "endurance : " + chienSelected.GetComponent<DogMovement>().Endurance; // Actualisation des stats
            VitesseMax.text = "vitesse max : " + chienSelected.GetComponent<DogMovement>().VitesseMax;
            Acceleration.text = "accélération : " + chienSelected.GetComponent<DogMovement>().Acceleration;
            VitesseMoyenne.text = "vitesse moyenne: " + chienSelected.GetComponent<DogMovement>().VitesseMoyenne;

            if (Input.GetMouseButtonDown(0) && !RaceStarted)
            {
                foreach (DogMovement dog in Chiens)
                {
                    dog.transform.position = StartPoint.position + new Vector3(_startDiff, 0, 0); // Mettre les chiens à pos. de départ et les écarter entre eux
                    _startDiff += 0.2f;
                }
                if (!CountdownStarted)
                {
                    StartCoroutine("RaceCountdown");
                    CountdownStarted = true;
                }
            }
        }

        for (int i = 0; i < Chiens.Length; i++) // Reset le scale du chien si déselectionné
        {
            if (Chiens[i].transform != chienSelected && !CountdownStarted) Chiens[i].transform.localScale = new Vector3(0.2f,0.2f,-0.2f);
        }
    }

    IEnumerator RaceCountdown()
    {
        Countdown.text = "3";
        yield return new WaitForSeconds(1f);
        Countdown.text = "2";
        yield return new WaitForSeconds(1f);
        Countdown.text = "1";
        yield return new WaitForSeconds(1f);
        Countdown.text = "GO";
        RaceStarted = true;
        yield return new WaitForSeconds(1f);
        Countdown.text = "";
    }

}