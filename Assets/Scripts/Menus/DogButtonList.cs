using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DogButtonList : MonoBehaviour
{
    public Image img; 
    public Text text;
    private Dog _dog;
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;

    public void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
    }

    public void SetImg(Sprite dogSprite)
    {
        img.sprite = dogSprite;
    }

    public void SetName(string dogName)
    {
        text.text = dogName;
    }

    public void SetDog(Dog newDog)
    {
        _dog = newDog;
        img.sprite = _dog.avatar;
        text.text = _dog.dogName;
    }

    public void OnClick()
    {
        trainingManager.SetSelectedDog(_dog);
    }


}
