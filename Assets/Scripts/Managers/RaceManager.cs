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
    public Text Countdown;

    public LayerMask ChienLayer;

    public bool RaceStarted;
    public bool CountdownStarted;
    public Transform StartPoint;
    public float StartDiff;

    private void Start()
    {
        Countdown.text = "";
        foreach (DogMovement chien in Chiens)
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

            if (Input.GetMouseButtonDown(0) && !RaceStarted)
            {
                foreach (DogMovement dog in Chiens)
                {
                    dog.transform.position = StartPoint.position + new Vector3(StartDiff, 0, 0);
                    StartDiff += 0.2f;
                }
                if (!CountdownStarted)
                {
                    StartCoroutine("RaceCountdown");
                    CountdownStarted = true;
                }
                
                
                
            }

        }

        for (int i = 0; i < Chiens.Length; i++)
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