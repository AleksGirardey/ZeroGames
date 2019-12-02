using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {
    public static MenuManager Instance;

    private static readonly Dictionary<string, EStateMenu> States = new Dictionary<string, EStateMenu> {
        {"MainMenu", EStateMenu.MainMenu},
        {"MainMenuCarrier", EStateMenu.MainMenuCarrier},
        {"EscapeMenu", EStateMenu.EscapeMenu},
        {"OptionsMenu", EStateMenu.OptionsMenu},
        {"SaveCarrierMenu", EStateMenu.SaveMenu},
        {"LoadCarrierMenu", EStateMenu.LoadMenu},
        {"GamePlayMenu", EStateMenu.GamePlayMenu},
        {"RaceMenu", EStateMenu.RaceMenu}
    };

    [Header("Escape Menu GameObjects")]
    public GameObject escapeMenu;
    public GameObject saveMenu;
    public GameObject loadMenu;

    [Header("Main Menu GameObjects")]
    public GameObject mainMenu;
    
    [Header("Main Menu - New Carrier GameObjects")]
    public GameObject mainMenuCarrier;

    [Header("Options GameObjects")]
    public GameObject options;

    [Header("GamePlayMenu GameObjects")]
    public GameObject gamePlayMenu;
    
    public bool isGamePaused = false;
    public DisplayMenu displayMenu;

    public string defaultState = "MainMenu";
    
    public StateMenu state;
    
    // Start is called before the first frame update
    void Start() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        state = new StateMenu(States[defaultState], null);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("escape")) {
            switch (state.CurrentState) {
                case EStateMenu.EscapeMenu:
                    state = state.FormerState;
                    UnloadMenu(EStateMenu.EscapeMenu);
                    break;
                case EStateMenu.MainMenu:
                    Quit();
                    break;
                case EStateMenu.MainMenuCarrier:
                    Back();
                    break;
                case EStateMenu.OptionsMenu:
                    Back();
                    break;
                default:
                    LoadMenu(EStateMenu.EscapeMenu, state.CurrentState);
                    state = new StateMenu(EStateMenu.EscapeMenu, state);
                    break;
            }
        }

        Time.timeScale = isGamePaused ? 0 : 1;
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void Back() {
        if (state.FormerState == null) {
            Application.Quit();
            return;
        }

        EStateMenu last = state.CurrentState;
        state = state.FormerState;
        LoadMenu(state.CurrentState, last);
    }
    
    private void UnloadMenu(EStateMenu menu) {
        switch (menu) {
            case EStateMenu.EscapeMenu:
                UnloadEscapeMenu();
                break;
            case EStateMenu.MainMenu:
                UnloadMainMenu();
                break;
            case EStateMenu.OptionsMenu:
                UnloadOptions();
                break;
            case EStateMenu.MainMenuCarrier:
                UnloadMainMenuCarrier();
                break;
            case EStateMenu.LoadMenu:
                UnloadLoadMenu();
                break;
            case EStateMenu.SaveMenu:
                UnloadSaveMenu();
                break;
            case EStateMenu.GamePlayMenu:
                UnloadGameplayMenu();
                break;
        }
    }
    private void LoadMenu(EStateMenu newMenu, EStateMenu lastMenu) {
        switch (newMenu) {
            case EStateMenu.EscapeMenu:
                LoadEscapeMenu();
                if (lastMenu == EStateMenu.OptionsMenu)
                    UnloadOptions();
                break;
            case EStateMenu.MainMenu:
                LoadMainMenu();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.OptionsMenu:
                LoadOptions();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.LoadMenu:
                LoadLoadMenu();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.SaveMenu:
                LoadSaveMenu();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.MainMenuCarrier:
                LoadMainMenuCarrier();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.GamePlayMenu:
                LoadGameplayMenu();
                UnloadMenu(lastMenu);
                break;
        }
    }

    public void LoadMenu(string newState) {
        LoadMenu(States[newState], state.CurrentState);
        state = new StateMenu(States[newState], state);
    }

    private void UnloadEscapeMenu() {
        isGamePaused = false;
        escapeMenu.SetActive(false);
    }

    private void LoadEscapeMenu() {
        isGamePaused = true;
        escapeMenu.SetActive(true);
    }

    private void UnloadMainMenu() {
        mainMenu.SetActive(false);
    }

    private void LoadMainMenu() {
        SceneManager.LoadScene("Scenes/MainMenu");
        mainMenu.SetActive(true);
    }

    private void UnloadMainMenuCarrier() {
        mainMenuCarrier.SetActive(false);
    }

    private void LoadMainMenuCarrier() {
        mainMenuCarrier.SetActive(true);
    }

    private void UnloadSaveMenu() {
        saveMenu.SetActive(false);
    }

    private void LoadSaveMenu() {
        saveMenu.SetActive(true);
    }

    private void UnloadLoadMenu() {
        loadMenu.SetActive(false);
    }

    private void LoadLoadMenu() {
        loadMenu.SetActive(true);
    }

    private void UnloadGameplayMenu() {
        gamePlayMenu.SetActive(false);
    }

    private void LoadGameplayMenu() {
        SceneManager.LoadScene("Scenes/GamePlayMenu");
        gamePlayMenu.SetActive(true);
    }

    private void UnloadOptions() {
        isGamePaused = false;
        options.SetActive(false);
    }

    private void LoadOptions() {
        isGamePaused = true;
        options.SetActive(true);
    }
    
    private void UnloadRaceMenu() {}
    private void LoadRaceMenu() {}
}
