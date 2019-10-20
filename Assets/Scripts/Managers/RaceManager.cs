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

    private void Start()
    {
        Countdown.text = "";
        foreach (DogMovement chien in Chiens) // Générer 4 chiens aléatoire parmis les 20 dans Assets/Ressources/Chiens
        {
            int i = Random.Range(0, ListeDesChiens.Length);

            chien.Endurance = ListeDesChiens[i].GetEndurance();
            chien.VitesseMax = ListeDesChiens[i].GetVitesseMax();
            chien.Acceleration = ListeDesChiens[i].GetAcceleration();
        }

    }

    private void Update()
    {
        if (!RaceStarted) SelectChien();
    }

    void SelectChien() // Choix du chien
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