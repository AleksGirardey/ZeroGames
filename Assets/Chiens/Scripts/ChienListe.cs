using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChienListe : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject BoutonSelectionChien;

    public Text Nom, VitesseMax, VitesseMoyenne, Endurance, Force, Acceleration, Mental;

    public Chien[] ListeDesChiens;

    public int IndexChienSelectionne;
    public Chien LeChienSelectionne;

    void Start()
    {

        // Création d'une liste de 8 chiens pour l'exemple

        ListeDesChiens = new Chien[4];
        ListeDesChiens[0] = new Chien("Chien1", 50, 50, 50, 50, 50);
        ListeDesChiens[1] = new Chien("Chien2", 33, 75, 40, 70, 70);
        ListeDesChiens[2] = new Chien("Chien3", 47, 75, 75, 75, 75);
        ListeDesChiens[3] = new Chien("Chien4", 36, 40, 20, 10, 30);

        // Pour chaque chien dans la liste, un bouton est instantié

        IndexChienSelectionne = -1;
        Nom.text = LeChienSelectionne.Nom;

        for (int i = 0 ; i < ListeDesChiens.Length ; i++)
        {

            GameObject BoutonChien = Instantiate(BoutonSelectionChien);

            BoutonChien.transform.SetParent(Canvas.transform);
            BoutonChien.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -30 * i - 30);     // On décale chaque bouton verticalement pour pas qu'ils ne se superposent
            BoutonChien.transform.GetChild(0).GetComponent<Text>().text = ListeDesChiens[i].Nom;

        }

    }

    public void Update()
    {

        if (EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.name == "BoutonSelectionChien(Clone)")   // Si un bouton de sélection de chien est cliqué
        {

            Nom.text = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;   // Mise à jour du nom du chien

            for (int i = 0; i < ListeDesChiens.Length; i++) if (Nom.text == ListeDesChiens[i].Nom) IndexChienSelectionne = i;

            if (LeChienSelectionne != ListeDesChiens[IndexChienSelectionne])
            {
                LeChienSelectionne = ListeDesChiens[IndexChienSelectionne];
            }

        }

        // On change les textes pour qu'ils correspondent aux statistiques du chien sélectionné

        if (Nom) Nom.text = LeChienSelectionne.Nom;
        if (VitesseMax) VitesseMax.text = "Vitesse max : " + LeChienSelectionne.VitesseMax.ToString() + " km/h";
        if (VitesseMoyenne) VitesseMoyenne.text = "Vitesse moyenne : " + LeChienSelectionne.VitesseMoyenne.ToString() + " km/h";
        if (Endurance) Endurance.text = "Endurance : " + LeChienSelectionne.Endurance.ToString();
        if (Force) Force.text = "Force : " + LeChienSelectionne.Force.ToString();
        if (Acceleration) Acceleration.text = "Accélération : " + LeChienSelectionne.Acceleration.ToString();
        if (Mental) Mental.text = "Mental : " + LeChienSelectionne.Mental.ToString();

    }

}