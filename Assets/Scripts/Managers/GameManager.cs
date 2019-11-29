using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Serialization;

/**
 * Main manager, handle the game, the player and the world
 */
public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public string date;
    public int money;
    public string greyhound;
    public string playername;
    
    private Game _game;

    //[FormerlySerializedAs("_player")] [SerializeField]
    //public Player[] player;

    [SerializeField]
    private Kennel _kennel;

    public World _world;

    public int i;

    public int Turns;
    public List<StatsChien> PlayerDogs; // IL A PAS AIMER QUE JE METTE CHIEN
    public List<Training> Trainings;
    public List<Player> Player;
    public Player selectedPlayer;

    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        PlayerDogs.Clear();
        DontDestroyOnLoad(gameObject);
        gameObject.tag = "GameManager";
        //PlayerDogs[0] = (StatsChien)AssetDatabase.LoadAssetAtPath("Assets/Ressources/PlayerDogs/Chien1", typeof(ScriptableObject));
        foreach (StatsChien st in Resources.LoadAll<StatsChien>("PlayerDogs"))
        {
            PlayerDogs.Add(st);
        }
        foreach (Training training in Resources.LoadAll<Training>("Trainings"))
        {
            Trainings.Add(training);
        }
        //player = Resources.Load<Player>("Player");
        foreach (Player player in Resources.LoadAll<Player>("Player"))
        {
            Player.Add(player);
        }
        selectedPlayer = Player[0];
    }

    private void Start()
    {
        //PlayerDogs[] = Resources.LoadAll<StatsChien>("Chiens");
        //Load();
        //player = new Player();
        
    }

    void Update() {
        GetPlayerStats();
        
    }

    public void GetPlayerStats()
    {
        date = selectedPlayer.daysPlayed.ToString() + "days";
        playername = selectedPlayer.profileName;
        money = selectedPlayer.money;
    }

    public void SetPlayerDog(int endu, int accel, int vmax)
    {
        PlayerDogs[0].Endurance = endu;
        PlayerDogs[0].Acceleration = accel;
        PlayerDogs[0].VitesseMax = vmax;
    }

    /*
    public void Save()
    {

        string PlayerJson = JsonUtility.ToJson(player);
        Debug.Log(PlayerJson);
        PlayerPrefs.SetString("SavedPlayerData", PlayerJson);

        string KennelJson = JsonUtility.ToJson(_kennel);
        Debug.Log(KennelJson);
        PlayerPrefs.SetString("SavedKennelData", KennelJson);

    }

    public void Load()
    {

        string SavedJsonPlayer = PlayerPrefs.GetString("SavedPlayerData");

        if (!string.IsNullOrEmpty(SavedJsonPlayer))
        {

            Player LoadedPlayerData = JsonUtility.FromJson<Player>(SavedJsonPlayer);
            player = LoadedPlayerData;

        }

        string SavedJsonKennel = PlayerPrefs.GetString("SavedKennelData");

        if (!string.IsNullOrEmpty(SavedJsonKennel))
        {

            Kennel LoadedKennelData = JsonUtility.FromJson<Kennel>(SavedJsonKennel);
            _kennel = LoadedKennelData;

        }

    }

    
    public void CreateNewGame()
    {

        player = new Player();

        player.money = 80;
        player.daysPlayed = 0;
        player.profileName = "nicolasHeinz";
        player.greyhound = "chien";

        _kennel = new Kennel();
        _kennel.SelectedDog = _world.AllDogs[i];

    }
    */
}