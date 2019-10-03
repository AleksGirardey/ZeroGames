using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class GraphVitesseMoyenne : MonoBehaviour
{
    public Chien chien = new Chien("a", 50, 50, 50, 50, 50);
    

    // Start is called before the first frame update
    void Start()
    {
        DrawGraphic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject dot;
    public GameObject stock;

    void DrawGraphic()
    {
        GetComponent<LineRenderer>().widrhg;

        /*GameObject Graph = this.gameObject;
        // Todo: Ajouter les fonctions qui permette de draw dans un UI le graphique de l'evolution de la vitesse sur le temps
        for (int i = 0; i <= 185; i++)
        {
            var Doto = Instantiate(dot, new Vector3(-70 + i,chien.Acceleration,1), transform.rotation);
            Doto.transform.SetParent(stock.transform,false);
        }*/
        
    }
}
