using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {
    public static MenuManager Instance;

    private static readonly Dictionary<String, EStateMenu> States = new Dictionary<string, EStateMenu> {
        {"MainMenu", EStateMenu.MainMenu},
        {"MainMenuCarrier", EStateMenu.MainMenuCarrier},
        {"EscapeMenu", EStateMenu.EscapeMenu},
        {"OptionsMenu", EStateMenu.OptionsMenu},
        {"GamePlayMenu", EStateMenu.GamePlayMenu},
        {"RaceMenu", EStateMenu.RaceMenu}
    };

    [Header("Escape Menu GameObjects")]
    public GameObject escapeMenu;

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

    public StateMenu state;
    
    // Start is called before the first frame update
    void Start() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        state = new StateMenu(EStateMenu.MainMenu, null);
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
                    Application.Quit();
                    break;
                case EStateMenu.OptionsMenu:
                    state = state.FormerState;
                    UnloadMenu(EStateMenu.OptionsMenu);
                    LoadMenu(EStateMenu.EscapeMenu, EStateMenu.OptionsMenu);
                    break;
                default:
                    LoadMenu(EStateMenu.EscapeMenu, state.CurrentState);
                    state = new StateMenu(EStateMenu.EscapeMenu, state);
                    break;
            }
        }

        Time.timeScale = isGamePaused ? 0 : 1;
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
        }
    }
    private void LoadMenu(EStateMenu newMenu, EStateMenu lastMenu) {
        switch (newMenu) {
            case EStateMenu.EscapeMenu:
                LoadEscapeMenu();
                break;
            case EStateMenu.MainMenu:
                LoadMainMenu();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.OptionsMenu:
                LoadOptions();
                UnloadMenu(lastMenu);
                break;
            case EStateMenu.MainMenuCarrier:
                LoadMainMenuCarrier();
                UnloadMenu(lastMenu);
                break;
        }
    }

    public void LoadMenu(string newState) {
        LoadMenu(States[newState], state.CurrentState); }

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

    private void UnloadGameplayMenu() {
        gamePlayMenu.SetActive(false);
    }

    private void LoadGameplayMenu() {
        SceneManager.LoadScene("Scenes/GamePlayMenu");
        gamePlayMenu.SetActive(true);
    }

    private void UnloadOptions() {
        isGamePaused = false;
    }

    private void LoadOptions() {
        isGamePaused = true;
    }
    
    private void UnloadRaceMenu() {}
    private void LoadRaceMenu() {}
}
