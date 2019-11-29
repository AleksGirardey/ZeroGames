using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour {
    private Text _date;
    
    // Start is called before the first frame update
    void Update() {
        _date = GetComponent<Text>();
        _date.text = GameManager.Instance.date;
    }
}
