using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

/**
 * Main manager, handle the game, the player and the world
 */
public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public string date = "01/01/2020";
    public string greyhound;
    public string playerName;
    
    private Game _game;

    [FormerlySerializedAs("_kennel")] [SerializeField]
    private Kennel kennel;

    [FormerlySerializedAs("_world")] public World world;

    [FormerlySerializedAs("Turns")] public int turns;
    [FormerlySerializedAs("Trainings")] public List<Training> trainings;
    [FormerlySerializedAs("Player")] public Player player;

    private void Start() {
/*        Dog[] dog = Resources.LoadAll<Dog>("DefaultDogs");
        
        if (dog.Length == 0) Debug.Log("Couldn't load dog");
        
        player = ScriptableObject.CreateInstance<Player>();
        player.money = 2500;
        player.profileName = "DefaultPlayer";
        player.kennel = new Kennel();
        player.kennel.kennelName = "defaultKennel";
        player.kennel.dogs.Add(dog[0]);
        Game game = ScriptableObject.CreateInstance<Game>();
        game.player = player;
        SetGame(game);*/
    }

    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        gameObject.tag = "GameManager";
        foreach (StatsChien dog in GameManager.Instance.world.AllDogs)
        {
            dog.trainingsCleared = false;
        }
    }
    
    private void Load() {
        foreach (Training training in Resources.LoadAll<Training>("Trainings"))
        {
            trainings.Add(training);
        }
        //player = Resources.Load<Player>("Player");
        player = _game.player;
    }

    public void SetGame(Object game) {
        _game = (Game) game;
        Load();
    }
}