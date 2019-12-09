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

    private void Start()
    {

        Laps = GameManager.Instance.turns;

        chienSelected = null;
        RankLine = 0;

        Countdown.text = "";
        foreach (DogMovement chien in Chiens) // Générer 4 chiens aléatoire parmis les 20 dans Assets/Ressources/Chiens
        {
            int i = Random.Range(0, ListeDesChiens.Length);

            chien.ThisDog = ListeDesChiens[i];

            chien.Endurance = ListeDesChiens[i].GetEndurance();
            chien.VitesseMax = ListeDesChiens[i].VitesseMax;
            chien.Acceleration = ListeDesChiens[i].GetAcceleration();
            chien.VitesseMoyenne = ListeDesChiens[i].VitesseMax / 2f;
            chien.VitesseMin = ListeDesChiens[i].VitesseMax / 2f;
            chien.LapsRemaining = Laps;
        }

    }

    private void Update()
    {
        if (!RaceStarted) SelectChien();

        if (RaceStarted && RankLine < 4)
        {
            Timet.text = Mathf.RoundToInt(Timer).ToString();
            Timer+= Time.deltaTime;
        }

        CheckLap();
        CamTrackDog();

        if (RankLine >= 4) DisplayScore();      // Lorsque la course est finie
    }

    void SelectChien() // Choix du chien
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer) && !CountdownStarted) // Quand la souris passe sur un chien
        {
            chienSelected = hit.transform;
            chienSelected.localScale = Vector3.one * 1.5f; // Rescale du chien selectionné

            if (chienSelected.GetComponent<DogMovement>() != null) {
                Name.text = chienSelected.GetComponent<DogMovement>().ThisDog.name;

                Endurance.text =
                    "endurance : " + chienSelected.GetComponent<DogMovement>().Endurance; // Actualisation des stats
                VitesseMax.text = "vitesse max : " + chienSelected.GetComponent<DogMovement>().VitesseMax;
                Acceleration.text = "accélération : " + chienSelected.GetComponent<DogMovement>().Acceleration;
                VitesseMoyenne.text = "vitesse moyenne: " + chienSelected.GetComponent<DogMovement>().VitesseMoyenne;
            }

            if (Input.GetMouseButtonDown(0) && !RaceStarted)    // La sélection a été faite
            {
                chienSelected.localScale = Vector3.one; // Rescale du chien selectionné

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
            if (Chiens[i].transform != chienSelected && !CountdownStarted) Chiens[i].transform.localScale = Vector3.one;
        }
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

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("GamePlayMenu");
    }

}