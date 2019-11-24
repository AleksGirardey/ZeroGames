using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMoney : MonoBehaviour {
    private Text _money;
    
    // Start is called before the first frame update
    void Start() {
        _money = GetComponent<Text>();
        _money.text = GameManager.Instance.player.money + " $";
    }
}
