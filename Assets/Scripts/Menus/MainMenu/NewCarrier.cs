using UnityEngine;
using UnityEngine.UI;

public class NewCarrier : MonoBehaviour {
    public Dog[] dogsAvailable = new Dog[3];
    
    private Image _chosenBlazon;
    private Dog _chosenDog;

    public void SetChosenBlazon(Object image) {
        _chosenBlazon = (Image) image;
    }

    public void SetChosenDog(int dogNumber) {
        _chosenDog = dogsAvailable[dogNumber];
    }
}