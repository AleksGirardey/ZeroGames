using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum EMenus {
    Kennel,
    Management,
    DogTrack,
    Training
}

public class DisplayMenu : MonoBehaviour {
    public GameObject kennelCanvasPrefab;
    public GameObject managementCanvasPrefab;
    public GameObject dogTrackCanvasPrefab;
    public GameObject trainingCanvasPrefab;

    public GameObject kennelView;
    public GameObject officeView;

    private GameObject _loadedScreen;

    private bool _loadScreen = true;
    public Menus displayedMenu;

    private void LoadScreen(GameObject prefab) {
        Destroy(_loadedScreen);
        _loadedScreen = Instantiate(prefab, transform, false);
        _loadScreen = false;
    }

    private void LoadOfficeView() {
        kennelView.SetActive(false);
        officeView.SetActive(true);
    }

    private void LoadKennelView() {
        kennelView.SetActive(true);
        officeView.SetActive(false);
    }

    private void Awake() {
        LoadScreen(kennelCanvasPrefab);
        LoadKennelView();
    }

    // Update is called once per frame
    void Update()
    {
        if (_loadScreen) {  
                switch (displayedMenu.choosedMenus)
                {
                    case EMenus.Kennel:
                        LoadScreen(kennelCanvasPrefab);
                        LoadKennelView();
                        break;
                    case EMenus.Management:
                        LoadScreen(managementCanvasPrefab);
                        LoadOfficeView();
                        break;
                    case EMenus.DogTrack:
                        LoadScreen(dogTrackCanvasPrefab);
                        LoadOfficeView();
                        break;
                    case EMenus.Training:
                        LoadScreen(trainingCanvasPrefab);
                        LoadKennelView();
                        break;
                    default:
                        LoadScreen(kennelCanvasPrefab);
                        LoadKennelView();
                        break;
                }
        }
    }

    public void SetDisplayedMenu(Menus menu) {
        displayedMenu = menu;
        _loadScreen = true;
    }
}
