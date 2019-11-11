﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour
{
    public bool isLocalized;

    public int fontSize = 30;
    public string key;
    public string value;

    private LocalizedText _localization;
    private TextMeshProUGUI _textMesh;

    // Todo : Faire en sorte de match la size du text en fonction de celle du GO
    void Awake()
    {
        _textMesh = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
              

        _textMesh.text = value;
        _textMesh.characterWidthAdjustment = 0.1f;
        _textMesh.fontSize = fontSize;

        Transform textTransform = _textMesh.transform;
        Vector3 localScale = transform.localScale;

        textTransform.localPosition = new Vector3(0, 0, 0);
        textTransform.localRotation = new Quaternion(0, 0, 0, 0);
        textTransform.localScale = new Vector3(
            1 / localScale.x,
            1 / localScale.y,
            1 / localScale.z);

        /*if (isLocalized)
        {
            _localization = go.AddComponent<LocalizedText>();
            _localization.key = key;
        }*/
    }

    private void Update()
    {
        _textMesh.text = value;
    }
}
