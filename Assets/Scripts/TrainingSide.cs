using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingSide : MonoBehaviour
{
    public GameObject Name;

    public GameObject DogFace;

    public string _Name;

    public Image Icon;


    private Text _text;

    private void Start()
    {
        _text = Name.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = GameManager.Instance.player.kennel.dogs[0].dogName;
        DogFace.GetComponent<Image>().sprite = GameManager.Instance.player.kennel.dogs[0].avatar;
    }
}
