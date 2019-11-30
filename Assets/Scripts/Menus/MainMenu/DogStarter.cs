using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogStarter : MonoBehaviour {
    public NewCarrier instance;

    public int dogIndex;
    public Text dogName;
    public Text accStat;
    public Text staStat;
    public Text maxSpeedStat;
    public Image avatar;
    
    // Start is called before the first frame update
    void Start() {
        Dog dog = instance.dogsAvailable[dogIndex];

        dogName.text = dog.dogName;
        accStat.text = dog.GetAccelerationAsLetter();
        staStat.text = dog.GetStaminaAsLetter();
        maxSpeedStat.text = dog.GetMaxSpeedAsLetter();
        avatar.sprite = dog.avatar;
    }
}
