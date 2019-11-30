using System;
using System.Collections.Generic;

public enum EStateMenu {
    MainMenu,
    MainMenuCarrier,
    SaveMenu,
    LoadMenu,
    EscapeMenu,
    OptionsMenu,
    GamePlayMenu,
    RaceMenu
}

public class StateMenu {
    public readonly EStateMenu CurrentState;
    public readonly StateMenu FormerState;

    public StateMenu(EStateMenu currentState, StateMenu formerState) {
        CurrentState = currentState;
        FormerState = formerState;
    }
}