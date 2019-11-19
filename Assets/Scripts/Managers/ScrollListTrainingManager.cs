using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollListTrainingManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    private GameManager GameManager;
    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < GameManager.PlayerDogs.Count; i++) // INSTANTIATE DES SPRITES DES CHIENS DU JOUEUR DANS MENU TRAINING
        {
            GameObject DogImgButton = Instantiate(buttonPrefab) as GameObject;
            DogImgButton.SetActive(true);
            DogImgButton.GetComponent<DogButtonList>().SetImg(GameManager.PlayerDogs[i].imgColor);
            DogImgButton.GetComponent<DogButtonList>().SetName(GameManager.PlayerDogs[i].Name);
            DogImgButton.GetComponent<DogButtonList>().SetDog(GameManager.PlayerDogs[i]);

            DogImgButton.transform.SetParent(buttonPrefab.transform.parent, false);
        }

    }

    void CreateButtons()
    {

    }

}
