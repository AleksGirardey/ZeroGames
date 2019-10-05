﻿using UnityEngine;

/**
 * Main manager, handle the game, the player and the world
 */
public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    
    private Game _game;
    private Player _player;
    private World _world;
    
    // Start is called before the first frame update
    void Start() {
        Instance = this;
    }
}
