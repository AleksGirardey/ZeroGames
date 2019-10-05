using ProtoKom;
using UnityEngine;

public class Sauvegarde : MonoBehaviour
{

    public GameObject TableauStats;
    int IndexChienSelectionne;

    public AudioClip savesound;
    public AudioClip loadSound;
    public AudioClip denied;

    void Start()
    {
        
    }
   
    void Update()
    {

        IndexChienSelectionne = TableauStats.GetComponent<ChienListe>().IndexChienSelectionne;

    }

    public void SaveChien()
    {

        Chien SavedChien = TableauStats.GetComponent<ChienListe>().LeChienSelectionne;

        string Json = JsonUtility.ToJson(SavedChien);
        Debug.Log(Json);
        PlayerPrefs.SetString("SavedChien", Json);

        TableauStats.GetComponent<AudioSource>().PlayOneShot(savesound);

    }

    public void LoadChien()
    {

        string SavedJsonChien = PlayerPrefs.GetString("SavedChien");

        if (SavedJsonChien != null && SavedJsonChien.Length > 0)
        {

            Chien LoadedChien = JsonUtility.FromJson<Chien>(SavedJsonChien);

                TableauStats.GetComponent<ChienListe>().LeChienSelectionne = LoadedChien;
                TableauStats.GetComponent<AudioSource>().PlayOneShot(loadSound);

        }

    }
}