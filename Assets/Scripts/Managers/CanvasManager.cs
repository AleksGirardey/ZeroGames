using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject BaseInfos;
    public GameObject StarterSelectionGO;
    public GameObject SaveLoadScreen;
    public GameObject MenuEsc;

    // Start is called before the first frame update
    void Start()
    {
        
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

}
