using System;
using UnityEngine;
using UnityEngine.UI;

public class KennelManager : MonoBehaviour
{
    public Dog selectedDog;
    public bool dogChanged;
    public event EventHandler OnDogChanged;

    public GameObject dogListContainer;
    public GameObject dogButtonPrefab;
    
    public Text dogName;
    public Image dogAvatar;
    
    public Text accelerationLetter;
    public Text enduranceLetter;
    public Text maxSpeedLetter;
    public Text moralLetter;
    public Text averageSpeedValue;

    public Text nature;

    public Text description;

    public Text history;
    
    private void Start() {
        FillDogListContainer();
        if (selectedDog == null) SetSelectedDog(GameManager.Instance.player.kennel.dogs[0]);
    }

    private void Update() {
        nature.text = LocalizationManager.Instance.GetLocalizedValue(selectedDog.NatureKey);
        description.text = LocalizationManager.Instance.GetLocalizedValue(selectedDog.DescriptionKey);
        DefineHistory();
    }

    private void FillDogListContainer() {
        Dog[] list = GameManager.Instance.player.kennel.dogs.ToArray();
        GameObject button;

        for (int i = 0; i < list.Length; i++) {
            button = Instantiate(dogButtonPrefab, dogListContainer.transform);
            button.transform.Find("DogName").GetComponent<Text>().text = list[i].dogName;
            button.transform.Find("DogImage").GetComponent<Image>().sprite = list[i].avatar;
            var i1 = i;
            button.GetComponent<Button>().onClick.AddListener(() => SetSelectedDog(list[i1]));
        }
    }
    
    private void UpdateDogVisual() { 
        dogName.text = selectedDog.dogName;
        dogAvatar.sprite = selectedDog.avatar;
        accelerationLetter.text = selectedDog.GetAccelerationAsLetter();
        enduranceLetter.text = selectedDog.GetStaminaAsLetter();
        maxSpeedLetter.text = selectedDog.GetMaxSpeedAsLetter();
        moralLetter.text = selectedDog.GetMoralAsLetter();
        averageSpeedValue.text = "" + selectedDog.MaxSpeedRun;
    }

    private void DefineHistory() {
        history.text = string.Format(LocalizationManager.Instance.GetLocalizedValue("GameplayMenu_Kennel_History"),
            selectedDog.Wins, selectedDog.MaxSpeedRun, selectedDog.MoneyEarned);
    }

    public void SetSelectedDog(Dog dog) {
        selectedDog = dog;
        UpdateDogVisual();
        OnDogChanged?.Invoke(this, e: EventArgs.Empty);
    }
}