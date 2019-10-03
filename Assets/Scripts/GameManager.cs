using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance;
    
    [SerializeField] private List<string> _dogsJson =  new List<string>();

    private readonly List<Chien> _dogs = new List<Chien>();
    
    public GameObject DogsListUi;
    public GameObject DogPrefab;

    public ScoreboardRace OneLapRace;
    public ScoreboardRace TwoLapsRace;
    public ScoreboardRace ThreeLapsRace;

    private void Start() {
        StreamReader reader;
        
        foreach (string json in _dogsJson) {
            reader = new StreamReader("Assets/Resources/Dogs/" + json + ".json");
            Chien newDog = JsonUtility.FromJson<Chien>(reader.ReadToEnd());
            _dogs.Add(newDog);
            GameObject newDogUi = Instantiate(DogPrefab);
            newDogUi.transform.SetParent(DogsListUi.transform);
            newDogUi.GetComponent<ChienUi>().Chien = newDog;
        }
        DrawScoreboards();

        Instance = this;
    }
    
    public void DrawScoreboards() {
        List<Chien> oneLap = new List<Chien>(_dogs);
        List<Chien> twoLaps = new List<Chien>(_dogs);
        List<Chien> threeLaps = new List<Chien>(_dogs);

        oneLap.Sort(Chien.CompareOneLap());
        twoLaps.Sort(Chien.CompareTwoLap());
        threeLaps.Sort(Chien.CompareThreeLap());

        OneLapRace.Leaderboard = oneLap;
        TwoLapsRace.Leaderboard = twoLaps;
        ThreeLapsRace.Leaderboard = threeLaps;
    }
}
