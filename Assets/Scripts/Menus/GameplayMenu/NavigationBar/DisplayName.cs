using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour {
    private Text _name;
    
    // Start is called before the first frame update
    void Update() {
        _name = GetComponent<Text>();
        _name.text = GameManager.Instance.Player.name;
    }
}
