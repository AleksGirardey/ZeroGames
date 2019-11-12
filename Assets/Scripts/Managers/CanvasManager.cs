using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject BaseInfos;
    public GameObject StarterSelectionGO;
    public GameObject SaveLoadScreen;
    public GameObject MenuEsc;
    public int DogMaxSpeed1, DogAccel1, DogStamina1, DogMaxSpeed2, DogAccel2, DogStamina2, DogAccel3, DogStamina3, DogMaxSpeed3;
    public Text DogMaxSpeed1txt, DogAccel1txt, DogStamina1txt, DogMaxSpeed2txt, DogAccel2txt, DogStamina2txt, DogAccel3txt, DogStamina3txt, DogMaxSpeed3txt;

    // Start is called before the first frame update
    void Start()
    {
        DogMaxSpeed1txt.text = DogMaxSpeed1.ToString();
        DogStamina1txt.text = DogStamina1.ToString();
        DogAccel1txt.text = DogAccel1.ToString();

        DogMaxSpeed2txt.text = DogMaxSpeed2.ToString();
        DogStamina2txt.text = DogStamina2.ToString();
        DogAccel2txt.text = DogAccel2.ToString();

        DogMaxSpeed3txt.text = DogMaxSpeed3.ToString();
        DogStamina3txt.text = DogStamina3.ToString();
        DogAccel3txt.text = DogAccel3.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {

            MenuEsc.SetActive(!MenuEsc.activeSelf);
            // A rajouter:  Time.timeScale = 0;

        }
    }

    public void Save()
    {
        print("lol");
    }

    public void MenuLoad()
    {
        SaveLoadScreen.SetActive(!SaveLoadScreen.activeSelf);
        MenuEsc.SetActive(false);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StarterSelection()
    {
        BaseInfos.SetActive(false);
        StarterSelectionGO.SetActive(true);
    }

    public void SelectChien1()
    {
        GameManager.Instance.SetPlayerDog(DogStamina1, DogAccel1, DogMaxSpeed1);
        SceneManager.LoadScene("GamePlayMenu");
    }

    public void SelectChien2()
    {
        GameManager.Instance.SetPlayerDog(DogStamina2, DogAccel2, DogMaxSpeed2);
        SceneManager.LoadScene("GamePlayMenu");
    }

    public void SelectChien3()
    {
        GameManager.Instance.SetPlayerDog(DogStamina3, DogAccel3, DogMaxSpeed3);
        SceneManager.LoadScene("GamePlayMenu");
    }

}
