﻿using UnityEngine;

public class ScrollListKennelManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.Player.kennel.dogs.Count; i++) // INSTANTIATE DES SPRITES DES CHIENS DU JOUEUR DANS MENU TRAINING
        {
            GameObject DogImgButton = Instantiate(buttonPrefab, buttonPrefab.transform.parent, false) as GameObject;
            DogImgButton.SetActive(true);
            DogImgButton.GetComponent<DogButtonListKennel>().SetDog(GameManager.Instance.Player.kennel.dogs[i]);
        }

    }

}