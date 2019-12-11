using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CostTraining : MonoBehaviour
{
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;
    [FormerlySerializedAs("GameManager")] public GameManager gameManager;

    private float Cost;

    public GameObject ValidateButton;

    // Start is called before the first frame update
    void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Cost = 50 * trainingManager.TrainingList.Count;

        GetComponent<Text>().text = Cost + "$";

        if (Cost > gameManager.player.money)
        {
            ValidateButton.GetComponent<Button>().enabled = false;
            ValidateButton.GetComponent<Image>().color = new Color32(72, 72, 72, 255);
        }
        else
        {
            ValidateButton.GetComponent<Button>().enabled = true;
            ValidateButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
