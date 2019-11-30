using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Serialization;

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

    public int Turns;
    public List<Training> Trainings;
    public Player Player;

    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        gameObject.tag = "GameManager";
    }
    
    private void Load() {
        foreach (Training training in Resources.LoadAll<Training>("Trainings"))
        {
            Trainings.Add(training);
        }
        //player = Resources.Load<Player>("Player");
        Player = _game.player;
    }

    public void SetGame(Object game) {
        _game = (Game) game;
        Load();
    }
}