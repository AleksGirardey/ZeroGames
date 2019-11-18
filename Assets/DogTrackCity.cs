using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogTrackCity : MonoBehaviour
{
    public GameObject Championship;
    public GameObject NoChampionship;

    public bool _championship;

    public void BringChoice()
    {
        if (_championship)
        {
            NoChampionship.SetActive(false);
            Championship.SetActive(true);
            Championship.GetComponent<RectTransform>().position = new Vector2(this.transform.position.x, this.transform.position.y + 80);
        }
        else
        {
            Championship.SetActive(false);
            NoChampionship.SetActive(true);
            NoChampionship.GetComponent<RectTransform>().position = new Vector2(this.transform.position.x, this.transform.position.y + 80);
        }
    }
}
