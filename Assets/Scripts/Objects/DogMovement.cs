<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField]
    public Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 dogPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    private Rigidbody DogPhysics;

    float TimeSpent;

    private StatsChien StatsChien;

    public float Endurance;
    public float Acceleration;
    public float VitesseMax;
    public float Vitesse;
    private bool EnduranceConsumed;

    public RaceManager RaceManager;

    void Start()
    {

        DogPhysics = GetComponent<Rigidbody>();
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 1f;
        coroutineAllowed = true;
        Vitesse = 0;

    }

    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

        if (RaceManager.RaceStarted) SpeedCalc();
    }

    public void SpeedCalc()
    {
        if (Vitesse < VitesseMax && !EnduranceConsumed)
        {
            PhaseAcceleration();
        }
        else
        {
            PhaseDeceleration();
        }
        Vitesse = Mathf.Clamp(Vitesse, 6, VitesseMax);

    }

    void PhaseAcceleration()
    {
        Vitesse += Time.deltaTime * Acceleration;
    }

    void PhaseDeceleration()
    {
        EnduranceConsumed = true;
        Vitesse -= Time.deltaTime * Acceleration * ((100 - Endurance) / 100);
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

            while (tParam < 1)
            {
                if ((dogPosition - transform.position).magnitude < speedModifier * 3f) // CHECK SI LE CHIEN A VRAIMENT ATTEINT LE POINT
                {
                tParam += Time.fixedDeltaTime * speedModifier; // SI OUI, ON AUGMENTE TPARAM DONT DOGPOSITION CALCULE LE NEXT POINT
                }

                var dir = dogPosition - transform.position;

                // CALCUL DU NEXT POINT
                dogPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

                // AJOUT DE LA FORCE AU CHIEN
                DogPhysics.AddForce(dir * Vitesse);
                
                // Affichage visuelle du next point (debug)
                // Debug.DrawLine(transform.position, dogPosition, Color.red, 0.1f);

                // Rotation du chien
                transform.rotation = Quaternion.LookRotation(Vector3.up, dir) * Quaternion.Euler(90, 0, 0);

                yield return new WaitForEndOfFrame();
            }
        tParam = 0f;

        // SWITCH DE BEZIER CURVE
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
            routeToGo = 0;

        coroutineAllowed = true;

    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField]
    public Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 dogPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    private Rigidbody DogPhysics;

    public float Endurance;
    public float Acceleration;
    public float VitesseMax;
    public float Vitesse;
    public float VitesseMoyenne;
    private bool EnduranceConsumed;
    private bool HasFinished;

    public RaceManager RaceManager;

    void Start()
    {
        DogPhysics = GetComponent<Rigidbody>();
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 1f;
        coroutineAllowed = true;
        Vitesse = 0;
        VitesseMoyenne = VitesseMax / 2;
    }

    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

        if (RaceManager.RaceStarted) SpeedCalc();
    }

    public void SpeedCalc()
    {
        if (Vitesse < VitesseMax && !EnduranceConsumed && !HasFinished)
        {
            PhaseAcceleration();
        }
        else
        {
            PhaseDeceleration();
        }
        Vitesse = Mathf.Clamp(Vitesse, 0, VitesseMax);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish" && RaceManager.RaceStarted)
        {
            HasFinished = true;
        }
    }

    void PhaseAcceleration()
    {
        Vitesse += Time.deltaTime * Acceleration;
    }

    void PhaseDeceleration()
    {
        EnduranceConsumed = true;
        if (!HasFinished)
        {
            Vitesse -= Time.deltaTime * Acceleration * ((100 - Endurance) / 100);
        }
        else
        {
            Vitesse -= Time.deltaTime;
        }
        
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

            while (tParam < 1)
            {
                if ((dogPosition - transform.position).magnitude < speedModifier * 3f) // CHECK SI LE CHIEN A VRAIMENT ATTEINT LE POINT
                {
                tParam += Time.fixedDeltaTime * speedModifier; // SI OUI, ON AUGMENTE TPARAM DONC DOGPOSITION CALCULE LE NEXT POINT
                }

                var dir = dogPosition - transform.position;

                // CALCUL DU NEXT POINT
                dogPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

                // AJOUT DE LA FORCE AU CHIEN
                DogPhysics.AddForce(dir * Vitesse);
                
                // Affichage visuelle du next point (debug)
                // Debug.DrawLine(transform.position, dogPosition, Color.red, 0.1f);

                // Rotation du chien
                transform.rotation = Quaternion.LookRotation(Vector3.up, dir) * Quaternion.Euler(90, 0, 0);

                yield return new WaitForEndOfFrame();
            }
        tParam = 0f;

        // SWITCH DE BEZIER CURVE
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
            routeToGo = 0;

        coroutineAllowed = true;

    }

}
>>>>>>> Stashed changes
