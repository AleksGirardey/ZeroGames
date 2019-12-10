using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public StatsChien[] ListeDesChiens = new StatsChien[20];

    public DogMovement[] Chiens = new DogMovement[4];

    public Text Timet;
    public float Timer = 0;
    public Text Name;
    public Text Endurance;
    public Text VitesseMax;
    public Text Acceleration;
    public Text VitesseMoyenne;
    public Text Countdown;
    public Text Ranking;

    public CameraFollow CameraF;

    public int Laps = 3;
    int PreviousLap = 3;
    public Text LapsText;

    public LayerMask ChienLayer;

    Transform chienSelected;

    public GameObject Bilan;
    public Text BilanTxt;
    public Text Profit;

    public bool RaceStarted;
    public bool RaceEnded;
    public bool CountdownStarted;
    public Transform StartPoint;

    private float _startDiff; // Ecarter les chiens au début

    int RankLine;

    private int i1, i2, i3;

    private void Start()
    {

        foreach (DogMovement dog in Chiens)
        {
            dog.transform.position = StartPoint.position + new Vector3(0, 0, _startDiff); // Mettre les chiens à pos. de départ et les écarter entre eux
            _startDiff += 2f;
        }

        RankLine = 0;

        Countdown.text = "";

        if (GameManager.Instance != null)
        {  // CHIEN DU JOUEUR

            Laps = GameManager.Instance.turns;

            Chiens[0].Endurance = GameManager.Instance.player.kennel.dogs[0].GetEndurance();
            Chiens[0].VitesseMax = GameManager.Instance.player.kennel.dogs[0].GetVitesseMax();
            Chiens[0].Acceleration = GameManager.Instance.player.kennel.dogs[0].GetAcceleration();


            if (Laps == 1) // 2 CHIENS AVEC GROSSE ACCEL
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
            else if (Laps == 2) // 2 CHIENS AVEC STATS MOYENNE (EN DESSOUS DE 30)
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
            else if (Laps == 3) // 2 CHIENS AVEC GROSSE ENDURANCE
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

        }

        chienSelected = Chiens[0].transform;
        StartCoroutine(RaceCountdown());

    }

    private void Update()
    {

        if (RaceStarted && RankLine < 4)
        {
            Timet.text = Mathf.RoundToInt(Timer).ToString();
            Timer+= Time.deltaTime;
        }

        CheckLap();
        CamTrackDog();
        DisplayChienStats();

        if (RankLine >= 4) DisplayScore();      // Lorsque la course est finie
    }

    public int DogRank(DogMovement RankedDog)   // Retourne le classement du chien RankedDog
    {

        int FinishedDogCount = 0;

        foreach (DogMovement chien in Chiens)
        {

            if (chien._hasFinished && chien != RankedDog) FinishedDogCount++;

        }

        return FinishedDogCount + 1;

    }

    public void CamTrackDog()
    {
        RaycastHit hit2;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2, ChienLayer)) // Quand la souris passe sur un chien
        {

            if (hit2.transform.GetComponent<DogMovement>() != null)
            {
                CameraF.Target = hit2.transform.gameObject;
            }
        }

    }

    void DisplayChienStats()
    {
        RaycastHit hit;
        Transform chienDIsplayed = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer)) // Quand la souris passe sur un chien
        {
            chienDIsplayed = hit.transform;

            if (chienDIsplayed != null)
            {
                Name.text = chienDIsplayed.GetComponent<DogMovement>().ThisDog.name;
                Endurance.text = "endurance : " + chienDIsplayed.GetComponent<DogMovement>().Endurance; // Actualisation des stats
                VitesseMax.text = "vitesse max : " + chienDIsplayed.GetComponent<DogMovement>().VitesseMax;
                Acceleration.text = "accélération : " + chienDIsplayed.GetComponent<DogMovement>().Acceleration;
                VitesseMoyenne.text = "vitesse moyenne: " + chienDIsplayed.GetComponent<DogMovement>().VitesseMoyenne;
                LapsText.text = chienDIsplayed.GetComponent<DogMovement>().LapsRemaining + "/" + Laps;
            }

        }
    }

    public void SetRank(DogMovement RankedDog)  // La liste des arrivants selon leur classement est générée
    {

        Ranking.enabled = true;
        Ranking.text += "\n" + DogRank(RankedDog) + ". " + RankedDog.ThisDog.name;

        RankedDog.ThisDog.LatestRank = DogRank(RankedDog);
        RankedDog.ThisDog.LatestRace = System.DateTime.Now.ToString();

        RankLine++;

    }

    public void DisplayScore()  // Affiche une interface qui rend compte de la course et permet de retourner au choix de carrière 
    {

        RankLine = 0;

        Bilan.SetActive(true);
        RaceEnded = true;

        int Rank = chienSelected.GetComponent<DogMovement>().ThisDog.LatestRank;
        string Prefix = "eme";

        float ProfitAmount = 0;

        if (Rank == 1)
        {
            Prefix = "er";
            ProfitAmount = 1000;
            BilanTxt.color = Color.green;
            Profit.color = Color.green;
        }

        BilanTxt.text = "Votre chien est arrive " + Rank + Prefix;
        Profit.text = "Gain : +" + ProfitAmount + "€";

        Win();

    }

    void CheckLap()
    {

        int u = 0;

        foreach (DogMovement chien in Chiens)
        {

            if (chien.LapsRemaining < PreviousLap) u++;
            if (u >= Chiens.Length) PreviousLap = chien.LapsRemaining;

        }

        LapsText.text = PreviousLap + "/" + Laps;

    }

    public void Win()
    {

        //

    }

    IEnumerator RaceCountdown()
    {

        CountdownStarted = true;

        Countdown.text = "3";
        yield return new WaitForSeconds(1f);
        Countdown.text = "2";
        yield return new WaitForSeconds(1f);
        Countdown.text = "1";
        yield return new WaitForSeconds(1f);

        RaceStarted = true;

        Countdown.text = "GO";
        yield return new WaitForSeconds(1f);
        Countdown.text = "";



    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("GamePlayMenu");
    }

}