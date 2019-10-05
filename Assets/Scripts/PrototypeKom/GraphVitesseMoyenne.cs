using UnityEngine;

namespace ProtoKom {
    public class GraphVitesseMoyenne : MonoBehaviour {
        public Chien chien = new Chien("a", 80, 100, 50, 10, 50);

        // Update is called once per frame
        void Update() {
            DrawGraphic();
        }

        public GameObject dot;
        public GameObject stock;

        public float showerA;
        public float showerB;

        void DrawGraphic() {
            float VitesseMaxDefault = 8;
            float AccelerationDefault = 2;
            float EnduranceDefault = 100;

            //Pause des variables car incapable d'utiliser le chien.VitesseMax etc

            float EnduranceConso = 1.5f;


            float TempsAcceleration = VitesseMaxDefault / AccelerationDefault;
            float VitesseAccelerationMoy =
                (1 / (TempsAcceleration))
                * VitesseMaxDefault
                * Mathf.Sqrt(AccelerationDefault / VitesseMaxDefault)
                * 0.66666666666f * Mathf.Pow(TempsAcceleration, 1.5f);

            float TempsEndurance = EnduranceDefault / EnduranceConso;
            float b = (1 / (EnduranceConso * EnduranceConso * TempsEndurance)) - (1 / TempsEndurance);
            float VitesseEnduMoy =
                (VitesseMaxDefault / TempsEndurance)
                * ((2 / b) * (Mathf.Sqrt((b * TempsEndurance) + 1) - 1));

            //variable utilisées dans les formules.


            GetComponent<LineRenderer>().sortingOrder = 1;
            GetComponent<LineRenderer>().material = new Material(Shader.Find("Sprites/Default"));
            GetComponent<LineRenderer>().material.color = Color.red;

            //Fait apparaitre la ligne dans la Scene.


            var points = new Vector3[137];
            //Creation de la liste des points pour la ligne.

            points[0] = new Vector3(0, 0, 0);
            //Initialisation de la courbe


            for (int i = 1; i < 137; i++) {
                if (i * 5 < VitesseAccelerationMoy * TempsAcceleration) {
                    points[i] = new Vector3((i * 5),
                        (i * 50) / (Mathf.Pow(
                            (i * 5) / (VitesseMaxDefault * Mathf.Sqrt(AccelerationDefault / VitesseMaxDefault)),
                            (2f / 3f))), 0);
                    //Courbe dans l'acceleration
                }
                else {
                    float distanceRaccourci = (i * 5) - (VitesseAccelerationMoy * TempsAcceleration);

                    points[i] =
                        new Vector3((i * 5), ((i * 50) - ((VitesseAccelerationMoy * TempsAcceleration) * 10)) /
                                             ((-b + Mathf.Sqrt(Mathf.Pow(b, 2)
                                                               + ((4 * Mathf.Pow(VitesseMaxDefault, 2)) /
                                                                  Mathf.Pow(distanceRaccourci, 2)))) /
                                              (2 * (Mathf.Pow(VitesseMaxDefault, 2) /
                                                    Mathf.Pow(distanceRaccourci, 2)))), 1);

                    //Courbe dans la decceleration.
                }

            }

            GetComponent<LineRenderer>().SetPositions(points);
            //Pause des points de la courbe.
        }
    }
}
