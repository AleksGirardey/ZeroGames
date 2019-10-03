using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[System.Serializable]
public class ChienUi : MonoBehaviour {
    public Text TextDogName;
    public Slider SliderVitesseMax;
    public Text VitesseMaxDefault;
    public Text VitesseMaxFinal;
    public Slider SliderAcceleration;
    public Text AccelerationDefault;
    public Text AccelerationFinal;
    public Slider SliderEndurance;
    public Text EnduranceDefault;
    public Text EnduranceFinal;

    public Text VitesseMoyenne;
    
    public Chien Chien;

    void Start() {
        TextDogName.text = Chien.Nom;

        SliderVitesseMax.onValueChanged.AddListener(OnVitesseMaxChange);
        SliderVitesseMax.value = Chien.VitesseMaxDefault;
        VitesseMaxDefault.text = Chien.VitesseMaxDefault + " =>";
        
        SliderAcceleration.onValueChanged.AddListener(OnAccelerationChange);
        SliderAcceleration.value = Chien.AccelerationDefault;
        AccelerationDefault.text = Chien.AccelerationDefault + " =>";
        
        SliderEndurance.onValueChanged.AddListener(OnEnduranceChange);
        SliderEndurance.value = Chien.EnduranceDefault;
        EnduranceDefault.text = Chien.EnduranceDefault + " =>";
    }
    
    public void OnVitesseMaxChange(float value) {
        Chien.VitesseMax = value;
        VitesseMaxFinal.text = "" + Chien.VitesseMax;
        VitesseMaxFinal.color = Chien.VitesseMax < Chien.VitesseMaxDefault ? Color.red : Color.green;
        CalculVitesseMoyenne();
    }
    
    public void OnAccelerationChange(float value) {
        Chien.Acceleration = value;
        AccelerationFinal.text = "" + Chien.Acceleration;
        AccelerationFinal.color = Chien.Acceleration < Chien.AccelerationDefault ? Color.red : Color.green;
        CalculVitesseMoyenne();
    }
    
    public void OnEnduranceChange(float value) {
        Chien.Endurance = value;
        EnduranceFinal.text = "" + Chien.Endurance;
        EnduranceFinal.color = Chien.Endurance < Chien.EnduranceDefault ? Color.red : Color.green;
        CalculVitesseMoyenne();
    }

    private void CalculVitesseMoyenne() {
        Chien.CalculVitesseMoyenne();
        VitesseMoyenne.text = Chien.VitesseMoyenne + " km / h";
    }
}