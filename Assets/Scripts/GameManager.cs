using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<string> _dogsJson =  new List<string>();

    private List<Chien> _dogs = new List<Chien>();
    
    public GameObject DogsListUi;
    public GameObject DogPrefab;

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
    }
}
