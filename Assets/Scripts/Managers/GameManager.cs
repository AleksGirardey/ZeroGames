using UnityEngine;
using UnityEditor;
/**
 * Main manager, handle the game, the player and the world
 */
public class GameManager : MonoBehaviour {

    public static GameManager Instance;


    
    private Game _game;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Kennel _kennel;

    public World _world;

    public int i;

    public TextGameObject MoneyText, ProfileText, DogText, TimePlayerText;

    public int Turns;
    public StatsChien[] PlayerDogs;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        gameObject.tag = "GameManager";
        //PlayerDogs[0] = (StatsChien)AssetDatabase.LoadAssetAtPath("Assets/Ressources/PlayerDogs/Chien1", typeof(ScriptableObject));

    }

    private void Start()
    {

        Load();

    }

    void Update() {

        // UpdateTextValue();

    }

    public void SetPlayerDog(int endu, int accel, int vmax)
    {
        PlayerDogs[0].Endurance = endu;
        PlayerDogs[0].Acceleration = accel;
        PlayerDogs[0].VitesseMax = vmax;
    }


    public void Save()
    {

        string PlayerJson = JsonUtility.ToJson(_player);
        Debug.Log(PlayerJson);
        PlayerPrefs.SetString("SavedPlayerData", PlayerJson);

        string KennelJson = JsonUtility.ToJson(_kennel);
        Debug.Log(KennelJson);
        PlayerPrefs.SetString("SavedKennelData", KennelJson);

    }

    public void Load()
    {

        string SavedJsonPlayer = PlayerPrefs.GetString("SavedPlayerData");

        if (SavedJsonPlayer != null && SavedJsonPlayer.Length > 0)
        {

            Player LoadedPlayerData = JsonUtility.FromJson<Player>(SavedJsonPlayer);
            _player = LoadedPlayerData;

        }

        string SavedJsonKennel = PlayerPrefs.GetString("SavedKennelData");

        if (SavedJsonKennel != null && SavedJsonKennel.Length > 0)
        {

            Kennel LoadedKennelData = JsonUtility.FromJson<Kennel>(SavedJsonKennel);
            _kennel = LoadedKennelData;

        }

    }

    public void CreateNewGame()
    {

        _player = new Player();

        _player._money = 0;
        _player._daysPlayed = 0;
        _player._profileName = "nicolasHeinz";
        _player._greyhound = "chien";

        _kennel = new Kennel();
        _kennel.SelectedDog = _world.AllDogs[i];

    }

    void UpdateTextValue()
    {

        MoneyText.value = _player._money.ToString();
        TimePlayerText.value = _player._daysPlayed.ToString();
        ProfileText.value = _player._profileName.ToString();
        DogText.value = _player._greyhound.ToString();

    }

}