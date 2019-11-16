using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour
{
    public bool isLocalized;

    public float fontSize;
    public string key;
    public string value;

    public float Scale;

    private ButtonLocalizedText _localization;
    private TextMeshProUGUI _textMesh;

    // Todo : Faire en sorte de match la size du text en fonction de celle du GO
    void Awake()
    {
        
        Scale = GetComponent<RectTransform>().anchorMax.x - GetComponent<RectTransform>().anchorMin.x;
        if (Scale < 0.02f)
        {
            Scale = GetComponent<RectTransform>().anchorMax.y - GetComponent<RectTransform>().anchorMin.y;
        }
        

        _textMesh = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        if (Scale < 0.05)
        {
            fontSize = ((Scale * 1000) / (Mathf.Pow(((float)_textMesh.text.Length), 0.5f)));
        }
        else
        {
            fontSize = ((Scale * 1000) / (Mathf.Pow(((float)_textMesh.text.Length), 1.1f-Scale)));
        }
        

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

        if (isLocalized)
        {
            _localization = this.gameObject.AddComponent<ButtonLocalizedText>();
            _localization.key = key;
        }
    }



    private void Update()
    {
        _textMesh.text = value;
        Scale = GetComponent<RectTransform>().anchorMax.x - GetComponent<RectTransform>().anchorMin.x;
        if (Scale < 0.02f)
        {
            Scale = GetComponent<RectTransform>().anchorMax.y - GetComponent<RectTransform>().anchorMin.y;
        }


        _textMesh = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        if (Scale < 0.05)
        {
            fontSize = ((Scale * 1000) / (Mathf.Pow(((float)_textMesh.text.Length), 0.5f)));
        }
        else
        {
            fontSize = ((Scale * 1000) / (Mathf.Pow(((float)_textMesh.text.Length), 1.1f - Scale)));
        }

        _textMesh.fontSize = fontSize;
    }
}
