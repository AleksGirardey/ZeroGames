using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class LocalizedText : MonoBehaviour {

    public string key;

    private Text _text;
    private TextMeshProUGUI _textMesh;

    private bool _isText;
    
    void Start() {
        _text = GetComponent<Text>();
        if (_text != null) {
            _isText = true;
            _text.text = LocalizationManager.Instance.GetLocalizedValue(key);
        } else {
            _isText = false;
            _textMesh = GetComponent<TextMeshProUGUI>();
            _textMesh.text = LocalizationManager.Instance.GetLocalizedValue(key);
        }
    }

    //Todo : remplacer update par un catch d evenement
    private void Update() {
        if (_isText)
            _text.text = LocalizationManager.Instance.GetLocalizedValue(key);
        else
            _textMesh.text = LocalizationManager.Instance.GetLocalizedValue(key);
    }
}
