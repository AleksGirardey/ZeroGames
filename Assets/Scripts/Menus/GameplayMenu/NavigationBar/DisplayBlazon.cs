using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBlazon : MonoBehaviour {
    private Image _blazon;
    
    // Start is called before the first frame update
    void Update() {
        _blazon = GetComponentInParent<Image>();
        _blazon.sprite = GameManager.Instance.player.kennel.blazon;
    }
}
