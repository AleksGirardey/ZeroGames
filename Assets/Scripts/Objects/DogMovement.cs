using System.Collections;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField]
    public Transform[] Routes;
    public float SpeedModifier;
        public float Endurance;
        public float Acceleration;
        public float VitesseMax;
        private float VitesseMin;
    public float Vitesse;
    public float VitesseMoyenne;
    public RaceManager RaceManager;

    private bool _coroutineAllowed;
    private Rigidbody _dogPhysics;
    private bool _enduranceConsumed;
    public bool _hasFinished;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _dogPosition;

    public StatsChien ThisDog;

    public Animator DogAnimator;

    float TerrainSize;

    void Start()
    {

        _dogPhysics = GetComponent<Rigidbody>();

        _routeToGo = 0;
        _tParam = 0f;
        SpeedModifier = 1f;
        _coroutineAllowed = true;

        Vitesse = 0;
        VitesseMoyenne = VitesseMax / 2;
        VitesseMin = VitesseMoyenne;
    }

    void Update()
    {
        if (_coroutineAllowed) {
            StartCoroutine(GoByTheRoute(_routeToGo));
        }

        if (RaceManager.RaceStarted) SpeedCalc();

        UpdateAnimation();
    }

    public void SpeedCalc()
    {
        if (Vitesse < VitesseMax && !_enduranceConsumed && !_hasFinished) {
            PhaseAcceleration();
        }
        else
        {
            PhaseDeceleration();
        }
        if (!_hasFinished) Vitesse = Mathf.Clamp(Vitesse, VitesseMin, VitesseMax);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && RaceManager.RaceStarted) {         // Quand le chien finit sa course
            _hasFinished = true;
            RaceManager.SetRank(this);
        }
    }

    void PhaseAcceleration()
    {
        Vitesse += Time.deltaTime * Acceleration;
    }

    void PhaseDeceleration()
    {
        _enduranceConsumed = true;
        if (!_hasFinished)
        {
            Vitesse -= Time.deltaTime * Acceleration * ((100 - Endurance) / 100);
        }
        else
        {
            Vitesse = 0;
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        _coroutineAllowed = false;
        Vector3 p0 = Routes[routeNumber].GetChild(0).position;
        Vector3 p1 = Routes[routeNumber].GetChild(1).position;
        Vector3 p2 = Routes[routeNumber].GetChild(2).position;
        Vector3 p3 = Routes[routeNumber].GetChild(3).position;

            while (_tParam < 1)
            {
                if ((_dogPosition - transform.position).magnitude < SpeedModifier * 3f) // CHECK SI LE CHIEN A VRAIMENT ATTEINT LE POINT
                {
                _tParam += Time.fixedDeltaTime * SpeedModifier; // SI OUI, ON AUGMENTE TPARAM DONC DOGPOSITION CALCULE LE NEXT POINT
                }

                var dir = _dogPosition - transform.position;

                // CALCUL DU NEXT POINT
                _dogPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                Mathf.Pow(_tParam, 3) * p3;

                // AJOUT DE LA FORCE AU CHIEN
                _dogPhysics.AddForce(dir * Vitesse * 12f);

                // Rotation du chien
                transform.rotation = Quaternion.LookRotation(Vector3.up, dir) * Quaternion.Euler(90, 0, 0);

                yield return new WaitForEndOfFrame();
            }
        _tParam = 0f;

        // SWITCH DE BEZIER CURVE
        _routeToGo += 1;
        if (_routeToGo > Routes.Length - 1)
            _routeToGo = 0;

        _coroutineAllowed = true;
    }

    void UpdateAnimation()
    {

        DogAnimator.SetFloat("Speed", Vitesse / 3f);
        DogAnimator.SetBool("IsMoving", RaceManager.RaceStarted && !_hasFinished);

    }

}