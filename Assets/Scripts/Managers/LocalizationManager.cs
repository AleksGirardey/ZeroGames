﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {
    public static LocalizationManager instance;
    
    private Dictionary<string, string> _localizedText;
    private bool _isReady = false;
    private string _missingTextString = "LocalizedTextNotFound";
    void Awake() {
        LoadLocalizedText("localizedText_en.json");
        
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName) {
        _localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath)) {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            foreach (var t in loadedData.items) {
                _localizedText.Add(t.key, t.value);
            }
            
            Debug.Log("Data loaded, dictionary contains " + _localizedText.Count + " entries.");
        } else {
            Debug.LogError("Cannot find file : " + fileName);
        }

        _isReady = true;
    }

    public string GetLocalizedValue(string key) {
        string result = _missingTextString;
        
        if (_localizedText.ContainsKey(key))
            result = _localizedText[key];

        return result;
    }
    
    public bool GetIsReady() {
        return _isReady;
    }
}
