using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProtoKom {
    [Serializable]
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
        public Text VitesseMoyenneTwoLaps;
        public Text VitesseMoyenneThreeLaps;

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
            GameManager.Instance.DrawScoreboards();
        }

        public void OnAccelerationChange(float value) {
            Chien.Acceleration = value;
            AccelerationFinal.text = "" + Chien.Acceleration;
            AccelerationFinal.color = Chien.Acceleration < Chien.AccelerationDefault ? Color.red : Color.green;
            CalculVitesseMoyenne();
            GameManager.Instance.DrawScoreboards();
        }

        public void OnEnduranceChange(float value) {
            Chien.Endurance = value;
            EnduranceFinal.text = "" + Chien.Endurance;
            EnduranceFinal.color = Chien.Endurance < Chien.EnduranceDefault ? Color.red : Color.green;
            CalculVitesseMoyenne();
            GameManager.Instance.DrawScoreboards();
        }

        private void CalculVitesseMoyenne() {
            Chien.CalculVitesseMoyenne();
            Chien.CalculVitesseMoyenneDeuxTournant();
            Chien.CalculVitesseMoyenneTroisTournant();
            VitesseMoyenne.text = "1 Lap  : " + Math.Round(Chien.VitesseMoyenne, 2) + " km / h";
            VitesseMoyenneTwoLaps.text = "2 Laps : " + Math.Round(Chien.VitesseMoyenneDeuxTournant, 2) + " km / h";
            VitesseMoyenneThreeLaps.text = "3 Laps : " + Math.Round(Chien.VitesseMoyenneTroisTournant, 2) + " km / h";
        }
    }
}