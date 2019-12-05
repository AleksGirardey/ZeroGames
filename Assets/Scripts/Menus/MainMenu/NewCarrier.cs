using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCarrier : MonoBehaviour {
    public Dog[] dogsAvailable = new Dog[3];

    private string _playerName;
    private string _kennelName;
    private string _greyhoundName;
    
    private Image _chosenBlazon;
    private Dog _chosenDog;

    public void SetPlayerName(Text playerName) { _playerName = playerName.text; }
    public void SetKennelName(Text kennelName) { _kennelName = kennelName.text; }
    public void SetGreyhoundName(Text companyName) { _greyhoundName = companyName.text; }
    
    public void SetChosenBlazon(Object image) {
        _chosenBlazon = (Image) image;
    }

    public void SetChosenDog(int dogNumber) {
        _chosenDog = dogsAvailable[dogNumber];
    }

    public void CreateNewCarrier() {
        if (_playerName.Equals("")
            || _kennelName.Equals("")
            || _greyhoundName.Equals("")
            || _chosenBlazon == null
            || _chosenDog == null) return;
        
        Game game = ScriptableObject.CreateInstance<Game>();
        Kennel kennel = new Kennel();
        kennel.kennelName = _kennelName;
        kennel.blazon = _chosenBlazon.sprite;
        Player player = ScriptableObject.CreateInstance<Player>();

        player.profileName = _playerName;
        player.kennel = kennel;
        player.money = 2000;
        
        Dog dog = Instantiate(_chosenDog);/*
        dog.Endurance = _chosenDog.Endurance;
        dog.Acceleration = _chosenDog.Acceleration;
        dog.VitesseMax = _chosenDog.VitesseMax;
        dog.LatestRace = "";
        dog.LatestRank = 0;*/
        dog.dogName = _greyhoundName;
        /*dog.age = _chosenDog.age;
        dog.avatar = _chosenDog.avatar;*/

        kennel.dogs = new List<Dog> {dog};
        kennel.kennelName = _kennelName;
        
        GameManager.Instance.SetGame(game);
        GameManager.Instance.player = player;
        GameManager.Instance.date = "01/01/2020";
        MenuManager.Instance.LoadMenu("GamePlayMenu");
    }
}