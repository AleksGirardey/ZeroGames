using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class TextMeshProButton : MonoBehaviour
{
    public bool isLocalized;
    private LocalizedText _localization;
    public string key;
    public string value;
    private TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();

        if (isLocalized)
        {
            _localization = gameObject.AddComponent<LocalizedText>();
            _localization.key = key;
        }
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = value;
    }

}