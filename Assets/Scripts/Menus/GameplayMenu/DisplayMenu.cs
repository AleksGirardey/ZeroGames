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

    private GameObject _loadedScreen;

    private bool _loadScreen = true;
    public Menus displayedMenu;

    private void LoadScreen(GameObject prefab) {
        Destroy(_loadedScreen);
        _loadedScreen = Instantiate(prefab, transform, false);
        _loadScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_loadScreen) {  
                switch (displayedMenu.choosedMenus)
                {
                    case EMenus.Kennel:
                        LoadScreen(kennelCanvasPrefab);
                        break;
                    case EMenus.Management:
                        LoadScreen(managementCanvasPrefab);
                        break;
                    case EMenus.DogTrack:
                        LoadScreen(dogTrackCanvasPrefab);
                        break;
                    case EMenus.Training:
                        LoadScreen(trainingCanvasPrefab);
                        break;
                    default:
                        LoadScreen(kennelCanvasPrefab);
                        break;
                }
        }
    }

    public void SetDisplayedMenu(Menus menu) {
        displayedMenu = menu;
        _loadScreen = true;
    }
}
