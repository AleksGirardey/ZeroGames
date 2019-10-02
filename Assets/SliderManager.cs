using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public int foodQuality, trainingFreq, trainingIntensity;
    public Slider FoodSlider, TrainingFreqSlider, TrainingIntensitySlider;
    public float VitesseMax, Acceleration, Endurance;
    public float VitesseMaxDefault = 50;
    public float AccelerationDefault = 50;
    public float EnduranceDefault = 50;
    public Text VmaxValue, EnduranceValue, AccelValue, VitesseMoyennetxt;
    public Image VmaxImg, EnduranceImg, AccelImg;

    public GameObject Liste;

    [SerializeField]
    public Modificateurs[] ModificateursFrequence = new Modificateurs[3];
    public Modificateurs[] ModificateursIntensity = new Modificateurs[3];
    public Modificateurs[] ModificateursQuality = new Modificateurs[3];



    // Start is called before the first frame update
    void Start()
    {
        // VMAX, ACCEL, ENDURANCE

        ModificateursIntensity[0] = new Modificateurs(2, 3, 3);
        ModificateursIntensity[1] = new Modificateurs(4, 8, -1);
        ModificateursIntensity[2] = new Modificateurs(6, 12, -5);

        ModificateursQuality[0] = new Modificateurs(-5, -4, 5);
        ModificateursQuality[1] = new Modificateurs(4, 2, 10);
        ModificateursQuality[2] = new Modificateurs(6, 8, 21);

        ModificateursFrequence[0] = new Modificateurs(5, 3, 0);
        ModificateursFrequence[1] = new Modificateurs(10, -5, -8);
        ModificateursFrequence[2] = new Modificateurs(18, -10, -16);
    }

    // Update is called once per frame
    void Update()
    {

        VitesseMaxDefault = Liste.GetComponent<ChienListe>().LeChienSelectionne.VitesseMax;
        AccelerationDefault = Liste.GetComponent<ChienListe>().LeChienSelectionne.Acceleration;
        EnduranceDefault = Liste.GetComponent<ChienListe>().LeChienSelectionne.Endurance;

        foodQuality = Mathf.RoundToInt(FoodSlider.value);
        trainingFreq = Mathf.RoundToInt(TrainingFreqSlider.value);
        trainingIntensity = Mathf.RoundToInt(TrainingIntensitySlider.value);


        VitesseMax = VitesseMaxDefault
            + ModificateursFrequence[trainingFreq - 1].GetModificateurVitesseMax()
            + ModificateursIntensity[trainingIntensity - 1].GetModificateurVitesseMax()
            + ModificateursQuality[foodQuality - 1].GetModificateurVitesseMax();


        Acceleration = AccelerationDefault
            + ModificateursFrequence[trainingFreq - 1].GetModificateurAcceleration()
            + ModificateursIntensity[trainingIntensity - 1].GetModificateurAcceleration()
            + ModificateursQuality[foodQuality - 1].GetModificateurAcceleration();


        Endurance = EnduranceDefault
            + ModificateursFrequence[trainingFreq - 1].GetModificateurEndurance()
            + ModificateursIntensity[trainingIntensity - 1].GetModificateurEndurance()
            + ModificateursQuality[foodQuality - 1].GetModificateurEndurance();

        VmaxValue.text = "" + VitesseMax;
        EnduranceValue.text = "" + Endurance;
        AccelValue.text = "" + Acceleration;

        VmaxImg.fillAmount = VitesseMax / 100;
        EnduranceImg.fillAmount = Endurance / 100;
        AccelImg.fillAmount = Acceleration / 100;

        VitesseMoyennetxt.text = VitesseMoyenneCalculee(VitesseMax, Acceleration, Endurance) + " km/h";

    }

    public float VitesseMoyenneCalculee(float vmax, float accel, float endur)
    {

        float Aire1 = (vmax * (vmax / accel)) / 2f;
        float Aire2 = ((vmax / ((1 - endur / 100) * accel)) * vmax) / 2f;
        float Integrale = Aire1 + Aire2;

        float Intervalle = (vmax / ((1 - endur / 100) * accel)) + (vmax / accel);

        return (Integrale * (1 / Intervalle));

    }

}