using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class ButtonLocalizedText : MonoBehaviour
{
    public string key;

    private Text _text;
    public TextMeshProUGUI _textMesh;

    private bool _isText;

    void Start()
    {
        _textMesh = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        if (_textMesh.text == null)
        {
            _isText = true;
            _text = transform.Find("Text (TMP)").GetComponent<Text>();
            _text.text = LocalizationManager.Instance.GetLocalizedValue(key);
        }
        else
        {
            _isText = false;
            _textMesh.text = LocalizationManager.Instance.GetLocalizedValue(key);
        }
    }

    //Todo : remplacer update par un catch d evenement
    private void Update()
    {
        if (_isText)
            _text.text = LocalizationManager.Instance.GetLocalizedValue(key);
        else
            _textMesh.text = LocalizationManager.Instance.GetLocalizedValue(key);
    }
}
