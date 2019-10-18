using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
<<<<<<< Updated upstream

    public StatsChien[] ListeDesChiens = new StatsChien[20];

    public DogMovement[] Chiens = new DogMovement[4];

    public Text Endurance;
    public Text VitesseMax;
    public Text Acceleration;
=======
    public StatsChien[] ListeDesChiens = new StatsChien[20];

    public DogMovement[] Chiens = new DogMovement[4];

    public Text Endurance;
    public Text VitesseMax;
    public Text Acceleration;
    public Text VitesseMoyenne;
>>>>>>> Stashed changes
    public Text Countdown;

    public LayerMask ChienLayer;

    public bool RaceStarted;
    public bool CountdownStarted;
    public Transform StartPoint;
<<<<<<< Updated upstream
    public float StartDiff;
=======
    private float StartDiff; // Ecarter les chiens au début
>>>>>>> Stashed changes

    private void Start()
    {
        Countdown.text = "";
<<<<<<< Updated upstream
        foreach (DogMovement chien in Chiens)
=======
        foreach (DogMovement chien in Chiens) // Générer 4 chiens aléatoire parmis les 20 dans Assets/Ressources/Chiens
>>>>>>> Stashed changes
        {
            int i = Random.Range(0, ListeDesChiens.Length);

            chien.Endurance = ListeDesChiens[i].GetEndurance();
            chien.VitesseMax = ListeDesChiens[i].GetVitesseMax();
            chien.Acceleration = ListeDesChiens[i].GetAcceleration();
        }

    }

    private void Update()
    {
<<<<<<< Updated upstream

        if (!RaceStarted) SelectChien();
=======
        if (!RaceStarted) SelectChien();
    }

    void SelectChien() // Choix du chien
    {
        RaycastHit hit;
        Transform ChienSelected = null;
>>>>>>> Stashed changes

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer) && !CountdownStarted) // Quand la souris passe sur un chien
        {
            ChienSelected = hit.transform;

<<<<<<< Updated upstream
    void SelectChien()
    {

        RaycastHit hit;
        Transform ChienSelected = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, ChienLayer) && !CountdownStarted) // Quand la souris passe sur un chien
        {

            ChienSelected = hit.transform;

            ChienSelected.localScale = new Vector3(0.5f,0.5f,-0.5f); // On rescale le chien

            Endurance.text = "endurance : " + ChienSelected.GetComponent<DogMovement>().Endurance; // Actualisation des stats
            VitesseMax.text = "vitesse max : " + ChienSelected.GetComponent<DogMovement>().VitesseMax;
            Acceleration.text = "accélération : " + ChienSelected.GetComponent<DogMovement>().Acceleration;

=======
            ChienSelected.localScale = new Vector3(0.5f,0.5f,-0.5f); // On rescale le chien

            Endurance.text = "endurance : " + ChienSelected.GetComponent<DogMovement>().Endurance; // Actualisation des stats
            VitesseMax.text = "vitesse max : " + ChienSelected.GetComponent<DogMovement>().VitesseMax;
            Acceleration.text = "accélération : " + ChienSelected.GetComponent<DogMovement>().Acceleration;
            VitesseMoyenne.text = "vitesse moyenne: " + ChienSelected.GetComponent<DogMovement>().VitesseMoyenne;

>>>>>>> Stashed changes
            if (Input.GetMouseButtonDown(0) && !RaceStarted)
            {
                foreach (DogMovement dog in Chiens)
                {
<<<<<<< Updated upstream
                    dog.transform.position = StartPoint.position + new Vector3(StartDiff, 0, 0);
=======
                    dog.transform.position = StartPoint.position + new Vector3(StartDiff, 0, 0); // Mettre les chiens à pos. de départ et les écarter entre eux
>>>>>>> Stashed changes
                    StartDiff += 0.2f;
                }
                if (!CountdownStarted)
                {
                    StartCoroutine("RaceCountdown");
                    CountdownStarted = true;
                }
<<<<<<< Updated upstream
                
                
                
            }

        }

        for (int i = 0; i < Chiens.Length; i++)
=======
            }
        }

        for (int i = 0; i < Chiens.Length; i++) // Reset le scale du chien si déselectionné
>>>>>>> Stashed changes
        {
            if (Chiens[i].transform != ChienSelected && !CountdownStarted) Chiens[i].transform.localScale = new Vector3(0.2f,0.2f,-0.2f);
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