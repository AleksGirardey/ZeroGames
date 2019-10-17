using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextManagement : MonoBehaviour
{
    private void Awake()
    {        
         DontDestroyOnLoad(this.gameObject);
    }

    string path;
    string jsonString;

    string retour;

    public string Langue;

    // Start is called before the first frame update
    public string TextDefiner(string ID)
    {
        if ( Langue == "francais")
        {
            path = "";
            path = Application.streamingAssetsPath + "/TextFrancais.json";
        }
        else if ( Langue == "anglais")
        {
            path = "";
            path = Application.streamingAssetsPath + "/TextAnglais.json";
        }
        
        jsonString = File.ReadAllText(path);
        StockData StockTexte = JsonUtility.FromJson<StockData>(jsonString);
        switch (ID)
        {
            case "":
                retour = "empty";
                break;
            case "sauvegarde":
                retour =  StockTexte.Sauvegarde;
                break;
            case "profil":
                retour = StockTexte.Profil;
                break;
            case "chien":
                retour = StockTexte.Chien;
                break;
            case "jour":
                retour = StockTexte.Jour;
                break;
            case "jouer":
                retour = StockTexte.Jouer;
                break;
            case "francais":
                retour = StockTexte.Francais;
                break;
            case "anglais":
                retour = StockTexte.Anglais;
                break;
            case "chenil":
                retour = StockTexte.Chenil;
                break;
            case "management":
                retour = StockTexte.Management;
                break;
            case "cynodrome":
                retour = StockTexte.Cynodrome;
                break;
            case "entrainement":
                retour = StockTexte.Entrainement;
                break;
            default:
                break;

        }

        return retour;
    }

    
}

[System.Serializable]
public class StockData
{
    public string Sauvegarde;
    public string Profil;
    public string Chien;
    public string Jour;
    public string Jouer;
    public string Francais;
    public string Anglais;
    public string Chenil;
    public string Management;
    public string Cynodrome;
    public string Entrainement;
}
