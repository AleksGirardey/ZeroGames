using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatName {
    Acceleration,
    Stamina,
    MaxSpeed,
    Mental
}

public class TrainingStatPreview : MonoBehaviour {

    public StatName stat;

    private TrainingManager _trainingManager;
    
    private Text  _baseStat;
    private Image _arrow;
    private Text  _predictStat;

    private float _before;
    private float _after;

    private readonly Color _better = new Color32(120, 255, 120, 255);
    private readonly Color _equal = new Color32(255, 164, 82, 255);
    private readonly Color _worse = new Color32(255, 41, 61, 255);
    
    void Start() {
        _trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        _baseStat = transform.Find("Before").GetComponent<Text>();
        _arrow = transform.Find("Arrow").GetComponent<Image>();
        _predictStat = transform.Find("After").GetComponent<Text>();
        SetUpBaseStat();
    }

    private void SetUpBaseStat() {
        Dog dog = _trainingManager.selectedDog;

        if (dog == null) { dog = GameManager.Instance.player.kennel.dogs[0]; }

        switch (stat) {
            case StatName.Acceleration:
                _baseStat.text = dog.GetAccelerationAsLetter();
                _before = dog.GetAcceleration();
                break;
            case StatName.Stamina:
                _baseStat.text = dog.GetStaminaAsLetter();
                _before = dog.GetEndurance();
                break;
            case StatName.MaxSpeed:
                _baseStat.text = dog.GetMaxSpeedAsLetter();
                _before = dog.GetVitesseMax();
                break;
            case StatName.Mental:
                _baseStat.text = dog.GetMoralAsLetter();
                _before = dog.Mental;
                break;
        }
    }

    void Update() {
        List<Training> list = _trainingManager.trainingList;

        _after = _before;
        
        for (int i = 0; i < list.Count; i++) {
            switch (stat) {
                case StatName.Acceleration:
                    _after += (list[i].AccelerationDef + list[i].AccelerationTempo);
                    break;
                case StatName.Stamina :
                    _after += (list[i].EnduranceDef + list[i].EnduranceTempo);
                    break;
                case StatName.MaxSpeed :
                    _after += (list[i].VitesseMaxDef + list[i].VitesseMaxTempo);
                    break;
                default : break;
            }
        }
        
        if (_after > _before) _arrow.color = _better;
        else if (_after < _before) _arrow.color = _worse;
        else _arrow.color = _equal;

        _predictStat.text = StatsChien.GetStatAsLetter(_after);
    }
}
